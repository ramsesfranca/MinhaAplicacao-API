using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;

namespace MinhaAplicacao.Dominio.Interfaces.Services
{
    public interface ICardapioServico : IServicoBase<int, Cardapio, ICardapioRepositorio>
    {
    }
}
