using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using MinhaAplicacao.Dominio.Interfaces.Services;

namespace MinhaAplicacao.Negocio.Services
{
    public class PedidoServico : ServicoBase<int, Pedido, IPedidoRepositorio>, IPedidoServico
    {
        public PedidoServico(IUnitOfWork unitOfWork, IPedidoRepositorio repositorio)
            : base(unitOfWork, repositorio)
        {
        }
    }
}
