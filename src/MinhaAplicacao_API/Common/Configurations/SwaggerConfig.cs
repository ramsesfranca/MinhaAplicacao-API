using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MinhaAplicacao_API.Common.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Minha API",
                    Version = "v1",
                    Description = "Projeto de estudo API",
                });
            });

            return services;
        }
    }
}