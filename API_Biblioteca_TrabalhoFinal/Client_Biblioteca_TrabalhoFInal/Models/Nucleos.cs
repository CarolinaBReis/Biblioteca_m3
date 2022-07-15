using System.ComponentModel.DataAnnotations;

namespace Client_Biblioteca_TrabalhoFinal.Models
{
    public class Nucleos
    {
        [Required]
        public int IDNucleo { get; set; }

        [Required]
        public string Nucleo { get; set; }
    }
}
