using API_Biblioteca_TrabalhoFinal.Data.JoinClasses;
using API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using API_Biblioteca_TrabalhoFinal.Models;

namespace API_Biblioteca_TrabalhoFinal.Data.Repository
{
    public class RepositoryObras : IRepositoryObras
    {
        private readonly AppDbContext _db;

        public RepositoryObras(AppDbContext db)
        {
            _db = db;
        }
        
        public bool CreateObra(Obras obra)
        {         
            _db.Obras.Add(obra);            
            return Save();
        }

        public bool CreateExemplaresObra(Obras_Nucleos obra_nucleo)
        {
            _db.Obras_Nucleos.Add(obra_nucleo);
            return Save();
        }

        public bool DeleteObra(string ISBN)
        {
            Obras obra = _db.Obras.Where(o => o.ISBN == ISBN).FirstOrDefault();
            List <Obras_Nucleos> obranucleos = _db.Obras_Nucleos.Where(o => o.ISBN == ISBN).ToList();

            _db.Obras.Remove(obra);

            foreach (Obras_Nucleos o in obranucleos)
            {
                _db.Obras_Nucleos.Remove(o);
            }
            
            return Save();
        }

        public IList<Obras_Join_Nucleos> GetExObraTotalNucleosISBN(string ISBN)
            // Retorna exemplares de uma obra distribuidos por todos os núcleos - pesquisa por ISBN
        {
            var join = (from o in _db.Obras
                        join x in _db.Obras_Nucleos on o.ISBN equals x.ISBN
                        join y in _db.Nucleos on x.IDNucleo equals y.IDNucleo
                        select new Obras_Join_Nucleos
                        {
                            ISBN = o.ISBN,
                            Titulo = o.Titulo,
                            Autor = o.Autor,
                            Editora = o.Editora,
                            Assunto = o.Assunto,
                            Nucleo = y.Nucleo,
                            Quantidade = x.Quantidade,
                            Disponivel = x.Disponivel,
                            Requisitado = x.Requisitado
                        }
                         );
            return join.Where(o => o.ISBN == ISBN).ToList();
        }

        public IList<Obras_Join_Nucleos> GetExObraTotalNucleosTitulo(string Titulo)
        // Retorna exemplares de uma obra distribuidos por todos os núcleos - pesquisa por Titulo
        {
            var join = (from o in _db.Obras
                        join x in _db.Obras_Nucleos on o.ISBN equals x.ISBN
                        join y in _db.Nucleos on x.IDNucleo equals y.IDNucleo
                        select new Obras_Join_Nucleos
                        {
                            ISBN = o.ISBN,
                            Titulo = o.Titulo,
                            Autor = o.Autor,
                            Editora = o.Editora,
                            Assunto = o.Assunto,
                            Nucleo = y.Nucleo,
                            Quantidade = x.Quantidade,
                            Disponivel= x.Disponivel,
                            Requisitado = x.Requisitado
                        }
                         );
            return join.Where(o => o.Titulo.ToLower().Trim() == Titulo.ToLower().Trim()).ToList();
        }

        public Obras GetObraISBN(string ISBN)
        {
            return _db.Obras.Where(o => o.ISBN == ISBN).FirstOrDefault();
        }

        public IList<Obras> GetObras()
        {
            return _db.Obras.ToList();
        }

        public IList<Obras> GetObrasAssunto(string Assunto)
        {
            return _db.Obras.Where(o => o.Assunto == Assunto).ToList();
        }

        public IList<Obras> GetObrasAutor(string Autor)
        {
            return _db.Obras.Where(o => o.Autor == Autor).ToList();
        }

        public IList<Obras_Join_Nucleos> GetObrasNucleo(string Nucleo)
        {
            var join = (from o in _db.Obras
                        join x in _db.Obras_Nucleos on o.ISBN equals x.ISBN
                        join y in _db.Nucleos on x.IDNucleo equals y.IDNucleo
                        select new Obras_Join_Nucleos
                        {
                            ISBN = o.ISBN,
                            Titulo = o.Titulo,
                            Autor = o.Autor,
                            Editora = o.Editora,
                            Assunto = o.Assunto,
                            Nucleo = y.Nucleo,
                            Quantidade = x.Quantidade,
                            Disponivel = x.Disponivel,
                            Requisitado = x.Requisitado
                        }
                         );
            return join.Where(o => o.Nucleo == Nucleo).ToList();
        }

        public Obras_Nucleos GetObraNucleo(int IDNucleo, string ISBN)
        {
            return _db.Obras_Nucleos.Where(o => o.ISBN == ISBN && o.IDNucleo == IDNucleo).FirstOrDefault();
        }

        public Obras GetObraTitulo(string Titulo)
        {
            return _db.Obras.Where(o => o.Titulo == Titulo).FirstOrDefault();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
               

        public bool UpdateObra(Obras obra)
        {
            _db.Obras.Update(obra);
            return Save();
        }

        public bool UpdateExemplaresObra(Obras_Nucleos obra_nucleo)
        {
            _db.Obras_Nucleos.Update(obra_nucleo);
            return Save();
        }
    }    
}
