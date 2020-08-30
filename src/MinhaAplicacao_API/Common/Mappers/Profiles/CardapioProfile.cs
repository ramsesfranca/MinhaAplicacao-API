using AutoMapper;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao_API.Common.Mappers.Profiles
{
    public class CardapioProfile : Profile
    {
        public CardapioProfile()
        {
            this.CreateMap<Cardapio, V1.Models.CardapioModel>().ReverseMap();
        }
    }
}
