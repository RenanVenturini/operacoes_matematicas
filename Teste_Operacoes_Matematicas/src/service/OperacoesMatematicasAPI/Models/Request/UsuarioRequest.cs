using System.ComponentModel.DataAnnotations;

namespace OperacoesMatematicasAPI.Models.Request
{
    public class UsuarioRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public string Senha { get; set; }
    }
}
