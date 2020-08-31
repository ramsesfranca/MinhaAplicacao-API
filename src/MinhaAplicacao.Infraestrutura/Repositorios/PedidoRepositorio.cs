using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;

namespace MinhaAplicacao.Infraestrutura.Repositorios
{
    public class PedidoRepositorio : RepositorioBase<int, Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(MinhaAplicacaoDbContext contexto)
            : base(contexto)
        {
        }
    }
}
