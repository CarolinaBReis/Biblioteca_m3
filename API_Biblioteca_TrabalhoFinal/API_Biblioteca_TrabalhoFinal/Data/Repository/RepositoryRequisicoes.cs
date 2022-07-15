using API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using API_Biblioteca_TrabalhoFinal.Models;

namespace API_Biblioteca_TrabalhoFinal.Data.Repository
{
    public class RepositoryRequisicoes : IRepositoryRequisicoes
    {
        private readonly AppDbContext _db;

        public RepositoryRequisicoes(AppDbContext db)
        {
            _db = db;
        }

        public bool CreateRequisicao(Requisicoes Requisicao)
        {
            Obras_Nucleos updatedisponivel = _db.Obras_Nucleos.Where(
                o => o.ISBN == Requisicao.ISBN && o.IDNucleo == Requisicao.IDNucleo
                ).FirstOrDefault();

            updatedisponivel.Disponivel -= 1;
            updatedisponivel.Requisitado += 1;

            Requisicao.DataDevolucao = null;

            _db.Requisicoes.Add(Requisicao);
            _db.Obras_Nucleos.Update(updatedisponivel);
            return Save();
        }

        public bool DevolucaoRequisicao(Requisicoes Requisicao)
        {
            Requisicoes requisicao = _db.Requisicoes.Where(
                o => o.ISBN == Requisicao.ISBN && o.IDNucleo == Requisicao.IDNucleo && o.NIF == Requisicao.NIF && o.DataDevolucao == null
                ).FirstOrDefault();

            Obras_Nucleos updatedisponivel = _db.Obras_Nucleos.Where(
                o => o.ISBN == Requisicao.ISBN && o.IDNucleo == Requisicao.IDNucleo
                ).FirstOrDefault();

            requisicao.DataDevolucao = DateTime.Now;
            updatedisponivel.Disponivel += 1;
            updatedisponivel.Requisitado -= 1;

            _db.Obras_Nucleos.Update(updatedisponivel);
            _db.Requisicoes.Update(requisicao);
            return Save();
        }

        public IList<Requisicoes> GetRequisicoes()
        {
            return _db.Requisicoes.ToList();
        }

        public Requisicoes GetRequisicao(string ISBN, int idNucleo, int NIF) // usada somente para detetar requisição a ser devolvida
        {
            return _db.Requisicoes.Where(o => o.ISBN == ISBN && o.IDNucleo == idNucleo 
                                            && o.NIF == NIF && o.DataDevolucao == null).FirstOrDefault();
        }

        public IList<Requisicoes> GetRequisicoesAtivas()
        {
            return _db.Requisicoes.Where(o => o.DataDevolucao == null).ToList();
        }

        public IList<Requisicoes> GetRequisicoesISBN(string ISBN)
        {
            return _db.Requisicoes.Where(o => o.ISBN == ISBN).ToList();
        }

        public IList<Requisicoes> GetRequisicoesLeitor(int NIF)
        {
            return _db.Requisicoes.Where(o => o.NIF == NIF).ToList();
        }

        public IList<Requisicoes> GetRequisicoesAtivasLeitor(int NIF)
        {
            return _db.Requisicoes.Where(o => o.NIF == NIF && o.DataDevolucao == null).ToList();
        }

        public IList<Requisicoes> GetRequisicoesNucleo(int IDNucleo)
        {
            return _db.Requisicoes.Where(o => o.IDNucleo == IDNucleo).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
