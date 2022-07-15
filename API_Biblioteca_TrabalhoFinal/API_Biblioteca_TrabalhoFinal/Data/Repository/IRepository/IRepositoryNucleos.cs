using API_Biblioteca_TrabalhoFinal.Models;

namespace API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository
{
    public interface IRepositoryNucleos
    {
        IList<Nucleos> GetNucleos();
        Nucleos GetNucleo(int idNucleo);
        bool CreateNucleo(Nucleos nucleo);
        bool DeleteNucleo(int idNucleo);
        bool UpdateNucleo(Nucleos nucleo);
        bool TransferObra(string ISBN, int IDNucleoSaida, int IDNucleoEntrada, int qtd);
        bool Save();
    }
}
