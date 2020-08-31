using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao.Infraestrutura.Mapeamentos
{
    public class PedidoMapeamento : BaseMapeamento<int, Pedido>
    {
        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            base.Configure(builder);
        }
    }
}
