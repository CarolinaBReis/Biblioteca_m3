using System.ComponentModel.DataAnnotations;

namespace API_Biblioteca_TrabalhoFinal.Models
{
    public class Obras_Nucleos // Tabela Obras_Nucleos
    {
        [Required]
        public int IDNucleo { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public int? Disponivel { get; set; }

        [Required]
        public int? Requisitado { get; set; }

    }
}
