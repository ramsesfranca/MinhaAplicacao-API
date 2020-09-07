using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao.Infraestrutura.Mapeamentos
{
    public class ComandaMapeamento : BaseMapeamento<int, Comanda>
    {
        public override void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.ToTable("Comandas");

            builder.Property(p => p.Codigo).IsRequired().HasColumnType("varchar(20)");

            base.Configure(builder);
        }
    }
}
