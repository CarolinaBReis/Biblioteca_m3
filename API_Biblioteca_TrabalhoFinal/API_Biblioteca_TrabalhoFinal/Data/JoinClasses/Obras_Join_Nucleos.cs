namespace API_Biblioteca_TrabalhoFinal.Data.JoinClasses
{
    public class Obras_Join_Nucleos
    {
        public string ISBN { get; set; }
        public string Titulo { get; set;}
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Assunto { get; set; }
        public string  Nucleo { get; set; }
        public int Quantidade { get; set; }
        public int? Disponivel { get; set; }
        public int? Requisitado { get; set; }
    }
}
