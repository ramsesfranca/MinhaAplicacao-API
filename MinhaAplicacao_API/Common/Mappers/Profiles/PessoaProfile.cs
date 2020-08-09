using AutoMapper;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao_API.Models;

namespace MinhaAplicacao_API.Common.Mappers.Profiles
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            this.CreateMap<Pessoa, PessoaModel>().ReverseMap();
        }
    }
}
