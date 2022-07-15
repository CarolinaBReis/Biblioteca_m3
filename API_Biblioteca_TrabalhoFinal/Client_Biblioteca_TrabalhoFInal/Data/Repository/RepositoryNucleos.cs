using Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using Client_Biblioteca_TrabalhoFinal.Models;

namespace Client_Biblioteca_TrabalhoFinal.Data.Repository
{
    public class RepositoryNucleos : Repository<Nucleos>, IRepositoryNucleos
    {
        private readonly IHttpClientFactory _ClientFactory;

        public RepositoryNucleos(IHttpClientFactory ClientFactory) : base(ClientFactory)
        {
            ClientFactory = _ClientFactory;
        }
    }
}
