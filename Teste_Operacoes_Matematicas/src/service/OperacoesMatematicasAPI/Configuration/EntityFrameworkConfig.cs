using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OperacoesMatematicasAPI.Data;

namespace OperacoesMatematicasAPI.Configuration
{
    public static class EntityFrameworkConfig
    {
        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OperacoesMatematicasContext>(options
                => options.UseSqlServer(configuration
                .GetConnectionString("OperacoesMatematicasConnection")));
        }
    }
}
