using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao.Infraestrutura.Mapeamentos
{
    public class CardapioMapeamento : BaseMapeamento<int, Cardapio>
    {
        public override void Configure(EntityTypeBuilder<Cardapio> builder)
        {
            builder.ToTable("Cardapios");

            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(80)");
            builder.Property(p => p.Preco).HasColumnType("decimal(18, 2)");

            base.Configure(builder);
        }
    }
}
