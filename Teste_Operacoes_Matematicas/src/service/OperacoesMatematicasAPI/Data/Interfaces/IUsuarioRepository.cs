using OperacoesMatematicasAPI.Data.Table;

namespace OperacoesMatematicasAPI.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(TbUsuario usuario);
        Task<TbUsuario> ObterUsuarioAsync(string username, string senha);
    }
}