using AutoMapper;
using MinhaAplicacao.Dominio.Entidades;
using System.Linq;

namespace MinhaAplicacao_API.Common.Mappers.Profiles
{
    public class ComandaProfile : Profile
    {
        public ComandaProfile()
        {
            this.CreateMap<Comanda, V1.Models.ComandaModel>()
                .ForMember(c => c.Total, opt => opt.MapFrom(m => m.Pedidos.Sum(p => p.Cardapio.Preco)))
                .ReverseMap();
        }
    }
}
