using System.ComponentModel.DataAnnotations;

namespace Client_Biblioteca_TrabalhoFinal.Models
{
    public class Leitores
    {
        [Required(ErrorMessage = "Por favor introduza um NIF válido")]
        [RegularExpression(@"^[0-9]{9}$")]
        public int NIF { get; set; }

        [Required(ErrorMessage = "Por favor introduza o seu nome")]
        public string Nome { get; set; }
        

        [Required(ErrorMessage = "Por favor introduza o seu apelido")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Por favor introduza um telefone válido")]
        [RegularExpression(@"^[0-9]{9}$")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Por favor introduza um email válido")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public string Email { get; set; }

        [Required(ErrorMessage ="A sua password deve ter pelo menos 8 digitos e deve conter letras maíusculas, mínusculas, números e caracteres especiais")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")]
        public string Password { get; set; }

        [Required]
        public DateTime DataRegisto { get; set; } 

        [Required]
        public string EstadoRegisto { get; set; } 

        public DateTime DataEstado { get; set; } 

        public bool Admin { get; set; }
    }
}
