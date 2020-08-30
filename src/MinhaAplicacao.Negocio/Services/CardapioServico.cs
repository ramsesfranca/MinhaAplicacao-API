using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using MinhaAplicacao.Dominio.Interfaces.Services;

namespace MinhaAplicacao.Negocio.Services
{
    public class CardapioServico : ServicoBase<int, Cardapio, ICardapioRepositorio>, ICardapioServico
    {
        public CardapioServico(IUnitOfWork unitOfWork, ICardapioRepositorio repositorio)
            : base(unitOfWork, repositorio)
        {
        }
    }
}
