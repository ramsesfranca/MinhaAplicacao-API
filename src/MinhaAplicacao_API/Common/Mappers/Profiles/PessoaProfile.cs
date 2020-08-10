using AutoMapper;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao_API.Common.Mappers.Profiles
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            this.CreateMap<Pessoa, V1.Models.PessoaModel>().ReverseMap();
            this.CreateMap<Pessoa, V2.Models.PessoaModel>().ReverseMap();
        }
    }
}
