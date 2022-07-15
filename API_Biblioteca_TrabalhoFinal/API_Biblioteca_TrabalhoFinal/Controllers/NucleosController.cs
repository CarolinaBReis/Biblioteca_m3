using API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using API_Biblioteca_TrabalhoFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca_TrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NucleosController : ControllerBase
    {
        private IRepositoryNucleos _repoNucleos;

        public NucleosController(IRepositoryNucleos repoNucleos)
        {
            _repoNucleos = repoNucleos;
        }

        [HttpGet]
        public List<Nucleos> GetNucleos()
        {
            return _repoNucleos.GetNucleos().ToList();
        }

        [HttpGet("{idnucleo}")]
        public Nucleos GetNucleo(int IDNucleo)
        {
            return _repoNucleos.GetNucleo(IDNucleo);
        }

        [HttpPost]
        public bool CreateNucleos(Nucleos nucleo)
        {
            return _repoNucleos.CreateNucleo(nucleo);
        }

        [HttpPatch]
        public bool UpdateNucleos(Nucleos nucleo)
        {
            return _repoNucleos.UpdateNucleo(nucleo);
        }

        [HttpPatch("TransferObra")]
        public bool TransferObra(string ISBN, int IDNucleoSaida, int IDNucleoEntrada, int qtd)
        {
            return _repoNucleos.TransferObra(ISBN, IDNucleoSaida, IDNucleoEntrada, qtd);
        }

        [HttpDelete("{idnucleo}")]
        public bool DeleteNucleos(int IDNucleo)
        {
            return _repoNucleos.DeleteNucleo(IDNucleo);
        }
    }
}
