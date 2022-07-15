using Client_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using Client_Biblioteca_TrabalhoFinal.Models;

namespace Client_Biblioteca_TrabalhoFinal.Data.Repository
{
    public class RepositoryObras_Nucleos : Repository<Obras_Nucleos>, IRepositoryObras_Nucleos
    {
        private readonly IHttpClientFactory _ClientFactory;

        public RepositoryObras_Nucleos(IHttpClientFactory ClientFactory) : base(ClientFactory)
        {
            ClientFactory = _ClientFactory;
        }
    }
}
