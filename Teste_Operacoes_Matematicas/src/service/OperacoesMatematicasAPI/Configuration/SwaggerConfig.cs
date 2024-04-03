using Microsoft.OpenApi.Models;

namespace OperacoesMatematicasAPI.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Usuario", Version = "v1" });
            });
        }
    }
}
