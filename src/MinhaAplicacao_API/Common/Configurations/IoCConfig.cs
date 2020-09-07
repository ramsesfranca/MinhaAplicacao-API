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
            services.AddScoped<ICardapioServico, CardapioServico>();
            services.AddScoped<IComandaServico, ComandaServico>();
            services.AddScoped<IPedidoServico, PedidoServico>();

            services.AddScoped<MinhaAplicacaoDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            services.AddScoped<ICardapioRepositorio, CardapioRepositorio>();
            services.AddScoped<IComandaRepositorio, ComandaRepositorio>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

            return services;
        }
    }
}
