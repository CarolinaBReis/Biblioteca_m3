using Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using Client_Biblioteca_TrabalhoFinal.Models;

namespace Client_Biblioteca_TrabalhoFinal.Data.Repository
{
    public class RepositoryObras : Repository<Obras>, IRepositoryObras
    {
        private readonly IHttpClientFactory _ClientFactory;

        public RepositoryObras(IHttpClientFactory ClientFactory) : base(ClientFactory)
        {
            ClientFactory = _ClientFactory;
        }
    }
}
