using API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository;
using API_Biblioteca_TrabalhoFinal.Models;

namespace API_Biblioteca_TrabalhoFinal.Data.Repository
{
    public class RepositoryNucleos : IRepositoryNucleos
    {
        private readonly AppDbContext _db;

        public RepositoryNucleos(AppDbContext db)
        {
            _db = db;
        }

        public bool CreateNucleo(Nucleos nucleo)
        {
            _db.Nucleos.Add(nucleo);
            return Save();
        }

        public bool DeleteNucleo(int idNucleo)
        {
            var nucleo = _db.Nucleos.Where(o => o.IDNucleo == idNucleo).FirstOrDefault();
            _db.Nucleos.Remove(nucleo);
            return Save();
        }

        public IList<Nucleos> GetNucleos()
        {
            return _db.Nucleos.ToList();
        }

        public Nucleos GetNucleo(int idNucleo)
        {
            return _db.Nucleos.Where(o => o.IDNucleo == idNucleo).FirstOrDefault();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNucleo(Nucleos nucleo)
        {
            _db.Nucleos.Update(nucleo);
            return Save();
        }
        public bool TransferObra(string ISBN, int IDNucleoSaida, int IDNucleoEntrada, int qtd)
        {
            var Obra_Nucleo_saida = _db.Obras_Nucleos.Where(o => o.ISBN == ISBN && o.IDNucleo == IDNucleoSaida).FirstOrDefault();
            var Obra_Nucleo_entrada = _db.Obras_Nucleos.Where(o => o.ISBN == ISBN && o.IDNucleo == IDNucleoEntrada).FirstOrDefault();

            if (Obra_Nucleo_saida.Quantidade - qtd >= 1)
            {
                Obra_Nucleo_saida.Quantidade = Obra_Nucleo_saida.Quantidade - qtd;
                Obra_Nucleo_saida.Disponivel = Obra_Nucleo_saida.Disponivel - qtd;

                Obra_Nucleo_entrada.Quantidade = Obra_Nucleo_entrada.Quantidade + qtd;
                Obra_Nucleo_entrada.Disponivel = Obra_Nucleo_entrada.Disponivel + qtd;


                _db.Obras_Nucleos.Update(Obra_Nucleo_saida);
                _db.Obras_Nucleos.Update(Obra_Nucleo_entrada);
                return Save();
            }
            else { return false; }
            
        }

    }
}
