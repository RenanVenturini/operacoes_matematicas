using OperacoesMatematicasAPI.Data.Table;
using OperacoesMatematicasAPI.Models.Request;

namespace OperacoesMatematicasAPI.Data.Interfaces
{
    public interface IUsuarioService
    {
        Task AdicionarUsuarioAsync(UsuarioRequest usuarioRequest);
        Task<Token> AutenticarAsync(Login login);
    }
}