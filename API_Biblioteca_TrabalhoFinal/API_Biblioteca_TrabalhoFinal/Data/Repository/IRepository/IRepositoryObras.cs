using API_Biblioteca_TrabalhoFinal.Data.JoinClasses;
using API_Biblioteca_TrabalhoFinal.Models;

namespace API_Biblioteca_TrabalhoFinal.Data.Repository.IRepository
{
    public interface IRepositoryObras
    {
        IList<Obras> GetObras();
        Obras GetObraISBN(string ISBN);
        Obras GetObraTitulo(string Titulo);
        IList<Obras> GetObrasAutor(string Autor);
        IList<Obras> GetObrasAssunto(string Assunto);
        IList<Obras_Join_Nucleos> GetObrasNucleo(string Nucleo); // Obter a lista de obras existente num nucleo
        Obras_Nucleos GetObraNucleo(int IDNucleo, string ISBN); // Obter exemplares duma obra num nucleo
        IList<Obras_Join_Nucleos> GetExObraTotalNucleosISBN(string ISBN);
        // Obter os exemplares duma obra em todos os núcleos por ISBN
        IList<Obras_Join_Nucleos> GetExObraTotalNucleosTitulo(string Titulo);
        // Obter os exemplares duma obra em todos os núcleos por Titulo

        bool CreateObra(Obras obra);
        bool CreateExemplaresObra(Obras_Nucleos obra_nucleo);
        bool DeleteObra(string ISBN);
        bool UpdateObra(Obras obra);
        bool UpdateExemplaresObra(Obras_Nucleos obra_nucleo);

        bool Save();
    }
}
