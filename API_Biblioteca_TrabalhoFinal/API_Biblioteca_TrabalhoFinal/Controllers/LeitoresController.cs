using API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using API_Biblioteca_TrabalhoFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca_TrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeitoresController : ControllerBase
    {
        private IRepositoryLeitores _repoLeitores;

        public LeitoresController(IRepositoryLeitores repoLeitores)
        {
            _repoLeitores = repoLeitores;
        }

        [HttpGet]

        public List<Leitores> GetListaLeitores()
        {
            return _repoLeitores.GetLeitores().ToList();
        }

        [HttpGet("{NIF}")]

        public Leitores GetLeitorNIF(int NIF)
        {
            return _repoLeitores.GetLeitor(NIF);
        }

        [HttpGet("{Nome}/{Apelido}")]

        public List<Leitores> GetLeitorNome(string Nome, string Apelido)
        {
            return _repoLeitores.GetLeitor(Nome, Apelido).ToList();
        }

        [HttpPost]

        public bool CreateLeitor(Leitores leitor)
        {
            return _repoLeitores.CreateLeitor(leitor);
        }

        [HttpDelete("{NIF}")]
        public bool DeleteLeitor(int NIF)
        {
            return _repoLeitores.DeleteLeitor(NIF);
        }

        [HttpPatch]

        public bool UpdateLeitor(Leitores leitor)
        {
            return _repoLeitores.UpdateLeitor(leitor);
        }

    }
}
