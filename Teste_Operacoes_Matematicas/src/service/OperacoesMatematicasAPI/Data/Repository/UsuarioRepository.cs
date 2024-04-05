using Microsoft.EntityFrameworkCore;
using OperacoesMatematicasAPI.Data.Interfaces;
using OperacoesMatematicasAPI.Data.Table;

namespace OperacoesMatematicasAPI.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly OperacoesMatematicasContext _context;

        public UsuarioRepository(OperacoesMatematicasContext context)
        {
            _context = context;
        }

        public async Task AdicionarUsuarioAsync(TbUsuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<TbUsuario> ObterUsuarioAsync(string username, string senha)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nome == username && u.Senha == senha);
            return usuario;
        }
    }
}
