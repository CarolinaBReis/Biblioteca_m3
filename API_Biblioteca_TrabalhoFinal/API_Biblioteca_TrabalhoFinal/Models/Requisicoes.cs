using System.ComponentModel.DataAnnotations;

namespace API_Biblioteca_TrabalhoFinal.Models
{
    public class Requisicoes // Tabela Requisições
    {
        [Required]
        public string ISBN { get; set; }

        [Required]
        public int IDNucleo { get; set; }

        [Required]
        public int NIF { get; set; }

        public DateTime DataRequisicao { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
