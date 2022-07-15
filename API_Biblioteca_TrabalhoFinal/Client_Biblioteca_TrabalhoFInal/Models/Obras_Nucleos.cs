using System.ComponentModel.DataAnnotations;

namespace Client_Biblioteca_TrabalhoFinal.Models
{
    public class Obras_Nucleos
    {
        [Required(ErrorMessage = "Introduza o ID do núcleo")]
        public int IDNucleo { get; set; }

        [Required(ErrorMessage = "Introduza o ISBN da Obra")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Introduza a quantidade de cópias existentes no núcleo")]
        public int Quantidade { get; set; }

        [Required]
        public int? Disponivel { get; set; }

        [Required]
        public int? Requisitado { get; set; }
    }
}
