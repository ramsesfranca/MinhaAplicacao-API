using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhaAplicacao.Infraestrutura;

namespace MinhaAplicacao_API.Common.Configurations
{
    public static class ConnectionConfig
    {
        public static IServiceCollection CarrearConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MinhaAplicacaoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
