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
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<TbUsuario> UsuarioPorIdAsync(int id)
            => await _context.Usuario.FirstOrDefaultAsync(u => u.UsuarioId == id);
        public async Task AtualizarUsuarioAsync(TbUsuario usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarUsuarioAsync(TbUsuario usuario)
        {
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
        }

    }
}
