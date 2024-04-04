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
        public async Task<TbUsuario> UsuarioPorIdAsync(int id)
            => await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        public async Task AtualizarUsuarioAsync(TbUsuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarUsuarioAsync(TbUsuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<TbUsuario> ObterPorEmailSenhaAsync(string email, string senha)
        {
            return await _context.Usuarios
              .Where(u => u.Email == email && u.Senha == senha)
              .FirstOrDefaultAsync();
        }
    }
}
