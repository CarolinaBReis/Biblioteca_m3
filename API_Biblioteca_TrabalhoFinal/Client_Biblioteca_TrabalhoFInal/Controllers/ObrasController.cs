using Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using Client_Biblioteca_TrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client_Biblioteca_TrabalhoFinal.Controllers
{
    public class ObrasController : Controller
    {
        private readonly IRepositoryObras _obrasRepo;
        private readonly IRepositoryObras_Nucleos _obras_nucleosRepo;
        private readonly IRepositoryNucleos _nucleosRepo;

        public ObrasController(IRepositoryObras obrasRepo, IRepositoryObras_Nucleos obras_nucleosRepo, IRepositoryNucleos nucleosRepo)
        {
            _obrasRepo = obrasRepo;
            _obras_nucleosRepo = obras_nucleosRepo;
            _nucleosRepo = nucleosRepo;
        }
        public IActionResult Index()
        {
            return View(new Obras()) ;
        }

        public async Task<IActionResult> GetObras()
        {
            return Json(new { data = await _obrasRepo.GetAllAsync(StaticDetails.APIObras)});
        }

        public async Task<IActionResult> CreateObra()
        {
            Obras obra = new Obras(); 
            return View(obra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Obras/CreateObra/{obra_qtd?}")]
        public async Task<IActionResult> CreateObra(Obras obra)
        {
               if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using var ms1 = new MemoryStream();
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    obra.Capa = p1;
                }

                await _obrasRepo.CreateAsync(StaticDetails.APIObras, obra);

                IList<Nucleos> nucleos = await _nucleosRepo.GetAllAsync(StaticDetails.APINucleos);
                int countNucleos = nucleos.Count();                

                for (int i = 0; i < countNucleos; i++)
                {
                    Obras_Nucleos obra_nucleo = new Obras_Nucleos();
                    obra_nucleo.IDNucleo = i+1;
                    obra_nucleo.ISBN = obra.ISBN;
                    obra_nucleo.Quantidade = 1;
                    obra_nucleo.Disponivel = 0;
                    obra_nucleo.Requisitado = 0;

                    await _obras_nucleosRepo.CreateAsync(StaticDetails.APIObras + "DistObra/", obra_nucleo);
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(obra);
        }       

        [HttpGet]
        [Route("Obras/UpdateObra/{ISBN}")]
        public async Task<IActionResult> UpdateObra(string ISBN)
        {
            Obras obra = new Obras();

            obra = await _obrasRepo.GetAsync(StaticDetails.APIObras + "ISBN/", ISBN);
            if (obra == null)
            {
                return NotFound();
            }
            return View(obra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateObra(Obras obra)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using var ms1 = new MemoryStream();
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    obra.Capa = p1;
                }
                else
                {
                    var capaDB = await _obrasRepo.GetAsync(StaticDetails.APIObras + "ISBN/", obra.ISBN);
                    obra.Capa = capaDB.Capa;
                }

                await _obrasRepo.UpdateAsync(StaticDetails.APIObras, obra);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(obra);
            }

        }

        [HttpGet]      
        [Route("Obras/UpdateExemplarObra/{ISBN}")]
        public async Task<IActionResult> UpdateExemplarObra(string ISBN)
        {         
            IList<Obras_Nucleos> obra_nucleos = await _obras_nucleosRepo.GetAllAsync(StaticDetails.APIObras + "DistObra/" + ISBN);

            if (obra_nucleos == null)
            {
                return NotFound();
            }
            return View(obra_nucleos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Obras/UpdateExemplarObra/{obras}")]

        public async Task<IActionResult> UpdateExemplarObra(List<Obras_Nucleos> obras)
        {
            if (ModelState.IsValid)
            { 
                for (int i = 0; i < obras.Count; i++)
                {
                    Obras_Nucleos obra = obras[i];
                    if (obra.Quantidade > 1)
                    {
                        int checkdif = (int)(obra.Quantidade - obra.Requisitado - 1);
                        if (checkdif > 0)
                        {
                            obra.Disponivel = checkdif;
                        }
                        else
                        {
                            obra.Disponivel = 0;
                        }
                    }
                    else { obra.Disponivel = 0; }
                    await _obrasRepo.UpdateAsyncObras_Nucleos(StaticDetails.APIObras_Nucleos, obra);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(obras);
            }

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteObra(string id) 
        {
            var status = await _obrasRepo.DeleteAsync(StaticDetails.APIObras, id);
            if (status)
            {
                return Json(new { success = true, message="Obra eliminada com sucesso" });
            }
            else
            {
                return Json(new { success = false, message = "Não foi possivel eliminar a obra" });
            }            
        }
    }
}
