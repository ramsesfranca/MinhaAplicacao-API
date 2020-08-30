using AutoMapper;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao_API.Common.Mappers.Profiles
{
    public class ComandaProfile : Profile
    {
        public ComandaProfile()
        {
            this.CreateMap<Comanda, V1.Models.ComandaModel>().ReverseMap();
        }
    }
}
