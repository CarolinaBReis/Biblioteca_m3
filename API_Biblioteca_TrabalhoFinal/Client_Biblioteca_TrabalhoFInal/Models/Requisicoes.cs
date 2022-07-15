using System.ComponentModel.DataAnnotations;

namespace Client_Biblioteca_TrabalhoFinal.Models
{
    public class Requisicoes
    {
        [Required(ErrorMessage ="Introduza o ISBN da obra a ser requisitada")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Introduza o ID do núcleo onde a requisição vai ser efetuada")]
        public int IDNucleo { get; set; }

        [Required(ErrorMessage = "Introduza o NIF do leitor requisitante")]
        public int NIF { get; set; }

        public DateTime DataRequisicao { get; set; } 
        public DateTime? DataDevolucao { get; set; } 
    }
}
