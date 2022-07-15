using API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using API_Biblioteca_TrabalhoFinal.Models;

namespace API_Biblioteca_TrabalhoFinal.Data.Repository
{
    public class RepositoryLeitores : IRepositoryLeitores
    {
        private readonly AppDbContext _db;

        public RepositoryLeitores(AppDbContext db)
        {
            _db = db;
        }

        public bool CreateLeitor(Leitores leitor)
        {
            _db.Leitores.Add(leitor);
            return Save();
        }

        public bool DeleteLeitor(int NIF)
        {
            Leitores leitor = _db.Leitores.Where(o => o.NIF == NIF).FirstOrDefault();
            _db.Leitores.Remove(leitor);
            return Save();
        }

        public Leitores GetLeitor(int NIF)
        {
            return _db.Leitores.Where(o => o.NIF == NIF).FirstOrDefault();
        }

        public IList<Leitores> GetLeitor(string Nome, string Apelido)
        {
            return _db.Leitores.Where
                (o => o.Nome.Trim().ToLower() == Nome.Trim().ToLower() 
                && o.Apelido.Trim().ToLower() == Apelido.Trim().ToLower()).ToList(); ;
        }

        public IList<Leitores> GetLeitores()
        {
            return _db.Leitores.ToList();
        }

        public bool UpdateLeitor(Leitores leitor)
        {
            _db.Leitores.Update(leitor);
            return Save();
        }
        
        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }     

        
    }
}
