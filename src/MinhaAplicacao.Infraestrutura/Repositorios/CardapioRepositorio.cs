using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;

namespace MinhaAplicacao.Infraestrutura.Repositorios
{
    public class CardapioRepositorio : RepositorioBase<int, Cardapio>, ICardapioRepositorio
    {
        public CardapioRepositorio(MinhaAplicacaoDbContext contexto)
            : base(contexto)
        {
        }
    }
}
