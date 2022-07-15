using System.ComponentModel.DataAnnotations;

namespace Client_Biblioteca_TrabalhoFinal.Models
{
    public class Obras
    {
        [Required(ErrorMessage ="Introduza o ISBN da Obra")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Introduza o titulo da Obra")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Introduza o autor da Obra")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Introduza a editora da Obra")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "Introduza o assunto da Obra")]
        public string Assunto { get; set; }
        public Byte[]? Capa { get; set; }
    }
}
