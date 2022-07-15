using API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using API_Biblioteca_TrabalhoFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca_TrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisicoesController : ControllerBase
    {
        private readonly IRepositoryRequisicoes _repoRequisicoes;

        public RequisicoesController(IRepositoryRequisicoes repoRequisicoes)
        {
            _repoRequisicoes = repoRequisicoes;
        }

        [HttpGet]
        public List<Requisicoes> GetRequisicoes()
        {
            return _repoRequisicoes.GetRequisicoes().ToList();
        }

        [HttpGet("RequisicoesAtivas")]
        public List<Requisicoes> GetRequisicoesAtivas()
        {
            return _repoRequisicoes.GetRequisicoesAtivas().ToList();
        }

        [HttpGet("Obra/{ISBN}")]
        public List<Requisicoes> GetRequisicoesISBN(string ISBN)
        {
            return _repoRequisicoes.GetRequisicoesISBN(ISBN).ToList();
        }

        [HttpGet("Nucleo/{IDNucleo}")]
        public List<Requisicoes> GetRequisicoesNucleo(int IDNucleo)
        {
            return _repoRequisicoes.GetRequisicoesNucleo(IDNucleo).ToList();
        }

        [HttpGet("Leitor/{NIF}")]
        public List<Requisicoes> GetRequisicoesLeitor(int NIF)
        {
            return _repoRequisicoes.GetRequisicoesLeitor(NIF).ToList();
        }

        [HttpGet("Leitor/Ativas/{NIF}")]
        public List<Requisicoes> GetRequisicoesAtivasLeitor(int NIF)
        {
            return _repoRequisicoes.GetRequisicoesAtivasLeitor(NIF).ToList();
        }

        [HttpGet("{ISBN}/{idNucleo}/{NIF}")]

        public Requisicoes GetRequisicao(string ISBN, int idNucleo, int NIF)
        {
            return _repoRequisicoes.GetRequisicao(ISBN, idNucleo, NIF);
        }


        [HttpPost]
        
        public bool CreateRequisicao(Requisicoes Requisicao)
        {
            return _repoRequisicoes.CreateRequisicao(Requisicao);
        }

        [HttpPatch]
        public bool DevolucaoRequisicao(Requisicoes Requisicao)
        {
            return _repoRequisicoes.DevolucaoRequisicao(Requisicao);
        }
    }
}
