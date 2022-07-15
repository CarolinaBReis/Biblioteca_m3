using System.ComponentModel.DataAnnotations;

namespace API_Biblioteca_TrabalhoFinal.Models
{
    public class Nucleos // Tabela Nucleos
    {
        [Key]
        public int IDNucleo { get; set; }

        [Required]
        public string Nucleo { get; set; }
    }
}
