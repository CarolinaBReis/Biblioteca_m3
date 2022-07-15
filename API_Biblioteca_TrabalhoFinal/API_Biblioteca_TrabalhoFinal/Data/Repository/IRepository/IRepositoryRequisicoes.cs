using API_Biblioteca_TrabalhoFinal.Models;

namespace API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository
{
    public interface IRepositoryRequisicoes
    {
        IList<Requisicoes> GetRequisicoes();
        IList<Requisicoes> GetRequisicoesAtivas();
        IList<Requisicoes> GetRequisicoesLeitor(int NIF);
        IList<Requisicoes> GetRequisicoesAtivasLeitor(int NIF);
        IList<Requisicoes> GetRequisicoesNucleo(int IDNucleo);
        IList<Requisicoes> GetRequisicoesISBN(string ISBN);
        Requisicoes GetRequisicao(string ISBN, int idNucleo, int NIF);
        bool CreateRequisicao(Requisicoes Requisicao);
        bool DevolucaoRequisicao(Requisicoes Requisicao);
        bool Save();
    }
}
