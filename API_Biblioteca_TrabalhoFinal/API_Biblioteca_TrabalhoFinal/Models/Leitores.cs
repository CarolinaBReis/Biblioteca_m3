using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Biblioteca_TrabalhoFinal.Models
{
    public class Leitores // Tabela Leitores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NIF { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Apelido { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime DataRegisto { get; set; }

        public string EstadoRegisto { get; set; }

        public DateTime DataEstado { get; set; }

        public bool Admin { get; set; }

    }
}