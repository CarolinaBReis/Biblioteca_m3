using API_Biblioteca_TrabalhoFinal.Data.JoinClasses;
using API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using API_Biblioteca_TrabalhoFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca_TrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasController : ControllerBase
    {
        private IRepositoryObras _repoObras;

        public ObrasController(IRepositoryObras repoObras)
        {
            _repoObras = repoObras;
        }

        [HttpGet]
        public List<Obras> GetObras()
        {
            return _repoObras.GetObras().ToList();
        }

        [HttpGet("ISBN/{ISBN}")]
        public Obras GetObrasISBN(string ISBN)
        {
            return _repoObras.GetObraISBN(ISBN);
        }


        [HttpGet("Titulo/{Titulo}")]
        public Obras GetObrasTitulo(string Titulo)
        {
            return _repoObras.GetObraTitulo(Titulo);
        }

        [HttpGet("Assunto/{Assunto}")]
        public List<Obras> GetObrasAssunto(string Assunto)
        {
            return _repoObras.GetObrasAssunto(Assunto).ToList();
        }

        [HttpGet("Autor/{Autor}")]
        public List<Obras> GetObrasAutor(string Autor)
        {
            return _repoObras.GetObrasAutor(Autor).ToList();
        }

        [HttpGet("DistObra/{ISBN}")]

        public List<Obras_Join_Nucleos> GetExObraTotalNucleosISBN(string ISBN)
        {
            return _repoObras.GetExObraTotalNucleosISBN(ISBN).ToList();
        }

        [HttpGet("DistObraTitulo/{Titulo}")]
        public List<Obras_Join_Nucleos> GetExObraTotalNucleosTitulo(string Titulo)
        {
            return _repoObras.GetExObraTotalNucleosTitulo(Titulo).ToList();
        }

        [HttpGet("DistObraNucleo/{Nucleo}")]
        public List<Obras_Join_Nucleos> GetObrasNucleo(string Nucleo)
        {
            return _repoObras.GetObrasNucleo(Nucleo).ToList();
        }

        [HttpGet("DistObraNucleo/{IDNucleo}/{ISBN}")]
        public Obras_Nucleos GetObraNucleo(int IDNucleo, string ISBN)
        {
            return _repoObras.GetObraNucleo(IDNucleo, ISBN);
        }

        [HttpPost]
        public bool CreateObra(Obras obra)
        {
            return _repoObras.CreateObra(obra);
        }

        [HttpPost("DistObra")]
        public bool CreateExemplaresObra(Obras_Nucleos obra_nucleo)
        {
            return _repoObras.CreateExemplaresObra(obra_nucleo);
        }

        [HttpPatch("DistObra")]
        public bool UpdateExemplaresObra(Obras_Nucleos obra_nucleo)
        {
            return _repoObras.UpdateExemplaresObra(obra_nucleo);
        }

        [HttpPatch]

        public bool UpdateObra(Obras obra)
        {
            return _repoObras.UpdateObra(obra);            
        }

        [HttpDelete("{ISBN}")]
        public bool DeleteObra(string ISBN)
        {
            return _repoObras.DeleteObra(ISBN);
        }

    }
}
