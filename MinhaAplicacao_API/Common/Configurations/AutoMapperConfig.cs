using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MinhaAplicacao_API.Common.Mappers.Profiles;

namespace MinhaAplicacao_API.Common.Configurations
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection CarregarAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(PessoaProfile).Assembly);

            return services;
        }
    }
}
