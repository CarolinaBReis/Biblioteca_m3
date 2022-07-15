using API_Biblioteca_TrabalhoFinal.Models;

namespace API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository
{
    public interface IRepositoryLeitores
    {
        IList<Leitores> GetLeitores();
        Leitores GetLeitor(int NIF);
        IList<Leitores> GetLeitor(string Nome, string Apelido);
        bool CreateLeitor(Leitores leitor);
        bool DeleteLeitor(int NIF);
        bool UpdateLeitor(Leitores leitor);

        bool Save();
    }
}
