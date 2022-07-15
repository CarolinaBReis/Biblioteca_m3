using Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using Client_Biblioteca_TrabalhoFinal.Models;

namespace Client_Biblioteca_TrabalhoFinal.Data.Repository
{
    public class RepositoryRequisicoes : Repository<Requisicoes>, IRepositoryRequisicoes
    {
        private readonly IHttpClientFactory _ClientFactory;

        public RepositoryRequisicoes(IHttpClientFactory ClientFactory) : base(ClientFactory)
        {
            ClientFactory = _ClientFactory;
        }
    }
}
