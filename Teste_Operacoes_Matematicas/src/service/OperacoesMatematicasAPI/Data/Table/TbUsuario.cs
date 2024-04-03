using System.ComponentModel.DataAnnotations;

namespace OperacoesMatematicasAPI.Data.Table
{
    public class TbUsuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

    }
}
