using Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using Client_Biblioteca_TrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client_Biblioteca_TrabalhoFinal.Controllers
{
    public class RequisicoesController : Controller
    {
        private readonly IRepositoryRequisicoes _requisicoesRepo;
        private readonly IRepositoryLeitores _leitoresRepo;
        private readonly IRepositoryObras_Nucleos _obras_nucleosRepo;

        public RequisicoesController(IRepositoryRequisicoes requisicoesRepo, IRepositoryLeitores leitoresRepo, IRepositoryObras_Nucleos obras_nucleosRepo)
        {
            _requisicoesRepo = requisicoesRepo;
            _leitoresRepo = leitoresRepo;
            _obras_nucleosRepo = obras_nucleosRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetRequisicoes()
        {
            return Json(new { data = await _requisicoesRepo.GetAllAsync(StaticDetails.APIRequisicoes) });
        }

        public async Task<IActionResult> CreateRequisicao()
        {
            Requisicoes requisicao = new Requisicoes();
            return View(requisicao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRequisicao(Requisicoes requisicao)
        {
            if (ModelState.IsValid) // valida modelo
            {
                IList<Requisicoes> reqsativas = await _requisicoesRepo.GetAllAsync(StaticDetails.APIRequisicoes + "Leitor/Ativas/" + requisicao.NIF);
                Leitores leitor = await _leitoresRepo.GetAsync(StaticDetails.APILeitores, requisicao.NIF.ToString());

                if (leitor == null || leitor.EstadoRegisto != "Ativo") // verifica se leitor existe e está ativo
                {
                    return Json(new { success = false, message = "Requisição não autorizada: Verifique o estado do leitor" });
                }
                else // verifica número de devoluções atrasadas depois da última atualização do estado do leitor
                {
                    IList<Requisicoes> todas_reqs_leitor = await _requisicoesRepo.GetAllAsync(StaticDetails.APIRequisicoes + "Leitor/" + requisicao.NIF);
                    DateTime data_estado = leitor.DataEstado;
                    int count = 0;

                    for (int i = 0; i < todas_reqs_leitor.Count; i++)
                    {
                        if (todas_reqs_leitor[i].DataDevolucao >= data_estado)
                        {
                            DateTime datareq = todas_reqs_leitor[i].DataRequisicao;
                            DateTime datadev = (DateTime)todas_reqs_leitor[i].DataDevolucao;
                            TimeSpan dif = datadev.Subtract(datareq);

                            if (dif.TotalDays >= 15)
                            {
                                count++;
                            }
                        }
                    }

                    if (count >= 3)
                    {
                        leitor.EstadoRegisto = "Suspenso";
                        leitor.DataEstado = DateTime.Now;

                        await _leitoresRepo.UpdateAsync(StaticDetails.APILeitores, leitor);
                        return Json(new { success = false, message = "Requisição não autorizada: Verifique o estado do leitor" });
                    }
                    else
                    {
                        if (reqsativas.Count() < 4 || reqsativas == null) // verifica número de requisições ativas
                        {
                            Obras_Nucleos checkdisp = new Obras_Nucleos();
                            checkdisp = await _obras_nucleosRepo.GetAsync(StaticDetails.APIObras + "DistObraNucleo/" + requisicao.IDNucleo + "/", requisicao.ISBN);
                            if (checkdisp.Disponivel == 0)
                            {
                                return Json(new { success = false, message = "Requisição não autorizada: Não existem exemplares disponíveis neste núcleo" });
                            }
                            else
                            {
                                await _requisicoesRepo.CreateAsync(StaticDetails.APIRequisicoes, requisicao);
                                return RedirectToAction(nameof(Index));
                            }                            
                        }
                        else
                        {
                            return Json(new { success = false, message = "Requisição não autorizada: Número de requisições em simultâneo excedido" });
                        }
                    }
                }            
            }
            else
            {
                return View(requisicao);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Requisicoes/DevolverRequisicao/{ISBN}/{idnucleo}/{nif}")]

        public async Task<IActionResult> DevolverRequisicao(string ISBN, int idnucleo, int nif)
        {
            Requisicoes requisicao = new Requisicoes();

            requisicao = await _requisicoesRepo.GetAsyncRequisicoes(StaticDetails.APIRequisicoes, ISBN, idnucleo, nif);

            if (ModelState.IsValid)
            {                
                await _requisicoesRepo.UpdateAsync(StaticDetails.APIRequisicoes, requisicao);
                return Json(new { success = true, message = "Registo de devolução efetuado com sucesso" });
            }
            else
            {
                return Json(new { success = false, message = "ERRO: Registo de devolução não foi efetuado" });
            }

        }


    }
}
