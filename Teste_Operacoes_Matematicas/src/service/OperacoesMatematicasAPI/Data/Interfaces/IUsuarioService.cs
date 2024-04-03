using OperacoesMatematicasAPI.Models.Request;
using OperacoesMatematicasAPI.Models.Response;

namespace OperacoesMatematicasAPI.Data.Interfaces
{
    public interface IUsuarioService
    {
        Task AdicionarUsuarioAsync(UsuarioRequest usuarioRequest);
        Task<UsuarioResponse> UsuarioPorIdAsync(int id);
        Task AtualizarUsuarioAsync(AtualizarUsuarioRequest atualizarUsuarioRequest);
        Task DeletarUsuarioAsync(int id);
    }
}