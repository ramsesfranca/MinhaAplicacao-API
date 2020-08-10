using Microsoft.Extensions.DependencyInjection;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using MinhaAplicacao.Dominio.Interfaces.Services;
using MinhaAplicacao.Infraestrutura;
using MinhaAplicacao.Infraestrutura.Repositorios;
using MinhaAplicacao.Negocio.Services;

namespace MinhaAplicacao_API.Common.Configurations
{
    public static class IoCConfig
    {
        public static IServiceCollection CarregarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IPessoaServico, PessoaServico>();

            services.AddScoped<MinhaAplicacaoDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();

            return services;
        }
    }
}