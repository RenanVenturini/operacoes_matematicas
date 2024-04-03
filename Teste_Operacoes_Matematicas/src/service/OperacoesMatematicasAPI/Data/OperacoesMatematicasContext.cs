using Microsoft.EntityFrameworkCore;
using OperacoesMatematicasAPI.Data.Table;
using System.Reflection;

namespace OperacoesMatematicasAPI.Data
{
    public class OperacoesMatematicasContext : DbContext
    {
        public OperacoesMatematicasContext(DbContextOptions<OperacoesMatematicasContext> options) : base(options) { }

        public DbSet<TbUsuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
