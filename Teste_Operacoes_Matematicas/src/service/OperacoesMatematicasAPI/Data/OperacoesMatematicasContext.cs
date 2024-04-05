using Microsoft.EntityFrameworkCore;
using OperacoesMatematicasAPI.Data.Table;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacoesMatematicasAPI.Data
{
    public class OperacoesMatematicasContext : DbContext
    {
        public OperacoesMatematicasContext(DbContextOptions<OperacoesMatematicasContext> options) : base(options) { }

        public DbSet<TbUsuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
