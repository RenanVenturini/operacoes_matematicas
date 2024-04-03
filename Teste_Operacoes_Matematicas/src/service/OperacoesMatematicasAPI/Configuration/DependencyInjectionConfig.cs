using OperacoesMatematicasAPI.Data.Interfaces;
using OperacoesMatematicasAPI.Data.Repository;
using OperacoesMatematicasAPI.Services;

namespace OperacoesMatematicasAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
