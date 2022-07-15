using Client_Biblioteca_TrabalhoFinal.Models;

namespace Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string url, string Id);
        Task<Obras_Nucleos> GetAsyncObra_Nucleos(string url, int Id, string isbn);
        Task<Requisicoes> GetAsyncRequisicoes(string url, string isbn, int idNucleo, int nif);
        Task<IList<T>> GetAllAsync(string url);
        Task <bool> DeleteAsync(string url, string Id);
        Task <bool> CreateAsync(string url, T objToCreate);
        Task <bool> UpdateAsync(string url, T objToUpdate);
        Task<bool> UpdateAsyncObras_Nucleos(string url, Obras_Nucleos objToUpdate);
    }
}
