namespace OperacoesMatematicasAPI.Data.Table
{
    public class Token
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string TokenJwt { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
