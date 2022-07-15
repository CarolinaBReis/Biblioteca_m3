using Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using Client_Biblioteca_TrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client_Biblioteca_TrabalhoFinal.Controllers
{
    public class NucleosController : Controller
    {
        private readonly IRepositoryNucleos _nucleosRepo;

        public NucleosController(IRepositoryNucleos nucleosRepo)
        {
            _nucleosRepo = nucleosRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetNucleos()
        {
            return Json(new { data = await _nucleosRepo.GetAllAsync(StaticDetails.APINucleos) });
        }

        public async Task<IActionResult> CreateNucleo()
        {
            Nucleos nucleo = new Nucleos();
            return View(nucleo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Nucleos/CreateNucleo/{nucleo?}")]
        public async Task<IActionResult> CreateNucleo(Nucleos nucleonovo)
        {

            if (ModelState.IsValid)
            {
                await _nucleosRepo.CreateAsync(StaticDetails.APINucleos, nucleonovo);
                return RedirectToAction(nameof(Index));
            }
            return View(nucleonovo);
        }

        [HttpGet]
        [Route("Nucleos/UpdateNucleo/{IDNucleo}")]
        public async Task<IActionResult> UpdateNucleo(int idnucleo)
        {
            Nucleos nucleo_edit = new Nucleos();

            nucleo_edit = await _nucleosRepo.GetAsync(StaticDetails.APINucleos, idnucleo.ToString());
            if (nucleo_edit == null)
            {
                return NotFound();
            }
            return View(nucleo_edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> UpdateNucleo(Nucleos nucleoedit)
        {
            if (ModelState.IsValid)
            {
                await _nucleosRepo.UpdateAsync(StaticDetails.APINucleos, nucleoedit);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(nucleoedit);
            }

        }

        [HttpDelete]
        [Route("Nucleos/DeleteNucleo/{idnucleo}")]
        public async Task<IActionResult> DeleteNucleo(string idnucleo)
        {
            var status = await _nucleosRepo.DeleteAsync(StaticDetails.APINucleos, idnucleo);
            if (status)
            {
                return Json(new { success = true, message = "Registo de núcleo eliminado com sucesso" });
            }
            else
            {
                return Json(new { success = false, message = "Não foi possivel eliminar o registo de núcleo" });
            }
        }
    }
}
