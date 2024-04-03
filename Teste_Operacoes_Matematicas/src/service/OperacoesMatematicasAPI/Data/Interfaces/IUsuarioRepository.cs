using OperacoesMatematicasAPI.Data.Table;

namespace OperacoesMatematicasAPI.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(TbUsuario usuario);
        Task<TbUsuario> UsuarioPorIdAsync(int id);
        Task AtualizarUsuarioAsync(TbUsuario usuario);
        Task DeletarUsuarioAsync(TbUsuario usuario);
    }
}