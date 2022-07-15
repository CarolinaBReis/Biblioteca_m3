using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Biblioteca_TrabalhoFinal.Models
{
    public class Obras // Tabela Obras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ISBN { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor{ get; set; }

        [Required]
        public string Editora { get; set; }

        [Required]
        public string Assunto { get; set; }

        public Byte[]? Capa { get; set; }

    }
}
