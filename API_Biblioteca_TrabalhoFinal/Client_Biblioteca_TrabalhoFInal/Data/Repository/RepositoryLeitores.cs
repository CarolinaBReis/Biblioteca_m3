using Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using Client_Biblioteca_TrabalhoFinal.Models;

namespace Client_Biblioteca_TrabalhoFinal.Data.Repository
{
    public class RepositoryLeitores : Repository <Leitores>, IRepositoryLeitores
    {
        private readonly IHttpClientFactory _ClientFactory;

        public RepositoryLeitores(IHttpClientFactory ClientFactory) : base(ClientFactory)
        {
            ClientFactory = _ClientFactory;
        }
    }
}
