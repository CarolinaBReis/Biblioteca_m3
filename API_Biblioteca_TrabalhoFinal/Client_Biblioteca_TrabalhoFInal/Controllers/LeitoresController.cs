using Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using Client_Biblioteca_TrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client_Biblioteca_TrabalhoFinal.Controllers
{
    public class LeitoresController : Controller
    {
        private readonly IRepositoryLeitores _leitoresRepo;
        private readonly IRepositoryRequisicoes _requisicoesRepo;

        public LeitoresController(IRepositoryLeitores leitoresRepo, IRepositoryRequisicoes requisicoesRepo)
        {
            _leitoresRepo = leitoresRepo;
            _requisicoesRepo = requisicoesRepo;
        }

        public IActionResult Index()
        {
            return View(new Leitores());
        }

        public async Task<IActionResult> GetLeitores()
        {
            return Json(new { data = await _leitoresRepo.GetAllAsync(StaticDetails.APILeitores) });
        }

        public async Task<IActionResult> CreateLeitor()
        {
            Leitores leitor = new Leitores();          
            return View(leitor);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Leitores/CreateLeitor/{leitor?}")]
        public async Task<IActionResult> CreateLeitor(Leitores leitor)
        {           

            if (ModelState.IsValid)
            {
                await _leitoresRepo.CreateAsync(StaticDetails.APILeitores, leitor);
                return RedirectToAction(nameof(Index));
            }
            return View(leitor);
        }

        [HttpGet]
        [Route("Leitores/UpdateLeitor/{NIF}")]
        public async Task<IActionResult> UpdateLeitor(int NIF)
        {
            Leitores leitor = new Leitores();

            leitor = await _leitoresRepo.GetAsync(StaticDetails.APILeitores, NIF.ToString());
            if (leitor == null)
            {
                return NotFound();
            }
            return View(leitor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateLeitor(Leitores leitor)
        {
            if (ModelState.IsValid)
            {              
                await _leitoresRepo.UpdateAsync(StaticDetails.APILeitores, leitor);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(leitor);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReativarLeitor(string id)
        {
            Leitores leitor = new Leitores();
            leitor = await _leitoresRepo.GetAsync(StaticDetails.APILeitores, id);
            leitor.EstadoRegisto = "Ativo";
            leitor.DataEstado = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _leitoresRepo.UpdateAsync(StaticDetails.APILeitores, leitor);
                return Json(new { success = true, message = "Leitor ativo" });
            }
            else
            {
                return Json(new { success = false, message = "ERRO: Não foi possivel ativar o leitor. Dados inválidos." });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuspenderLeitor(string id)
        {
            Leitores leitor = new Leitores();
            leitor = await _leitoresRepo.GetAsync(StaticDetails.APILeitores, id);
            leitor.EstadoRegisto = "Suspenso";
            leitor.DataEstado = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _leitoresRepo.UpdateAsync(StaticDetails.APILeitores, leitor);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json(new { success = false, message = "ERRO: Não foi possivel suspender o leitor. Dados inválidos." });
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteLeitor(string id)
        {
            Requisicoes ultima_req = new Requisicoes();
            ultima_req.DataRequisicao = DateTime.MinValue;
            IList<Requisicoes> reqs_leitor = await _requisicoesRepo.GetAllAsync(StaticDetails.APIRequisicoes + "Leitor/" + id);
            IList<Requisicoes> reqs_ativas_leitor = await _requisicoesRepo.GetAllAsync(StaticDetails.APIRequisicoes + "Leitor/Ativas/" + id);

            if (reqs_leitor.Count != 0)
            { // se leitor fez requisições é necessário verificar se há requisições ativas e data da última requisição
                if (reqs_ativas_leitor.Count < 1)
                {
                    for (int i = 0; i < reqs_leitor.Count; i++)
                    {
                        if (reqs_leitor[i].DataRequisicao > ultima_req.DataRequisicao)
                        {
                            ultima_req = reqs_leitor[i];
                        }
                    }

                    TimeSpan dias = DateTime.Now.Subtract(ultima_req.DataRequisicao);

                    if (dias.TotalDays > 365.00) // condição que verifica se última requisição foi há mais de um ano
                    {
                        var status = await _leitoresRepo.DeleteAsync(StaticDetails.APILeitores, id);
                        if (status)
                        {
                            return Json(new { success = true, message = "Registo de leitor eliminado com sucesso" });
                        }
                        else
                        {
                            return Json(new { success = false, message = "ERRO: Não foi possivel eliminar o registo de leitor. Dados incorretos." });
                        }
                    }
                    else
                    {
                        return Json(new { success = false, message = "ERRO: Não foi possivel eliminar o registo de leitor. Última requisição há menos de um ano." });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "ERRO: Não foi possivel eliminar o registo de leitor. Tem pelo menos uma obra requisitada a aguardar devolução." });
                }
                
            }
            else // leitor sem requisições, permitir delete se model estiver válido
            {
                var status = await _leitoresRepo.DeleteAsync(StaticDetails.APILeitores, id);
                if (status)
                {
                    return Json(new { success = true, message = "Registo de leitor eliminado com sucesso" });
                }
                else
                {
                    return Json(new { success = false, message = "ERRO: Não foi possivel eliminar o registo de leitor" });
                }
            }           

            
        }

    }
}
