using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao.Infraestrutura.Mapeamentos
{
    public class PessoaMapeamento : BaseMapeamento<int, Pessoa>
    {
        public override void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");

            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(80)");
            builder.Property(p => p.Sexo);
            builder.Property(p => p.Email).HasColumnType("varchar(80)");
            builder.Property(p => p.DataNascimento).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.Nacionalidade).HasColumnType("varchar(80)");
            builder.Property(p => p.Naturalidade).HasColumnType("varchar(80)");
            builder.Property(p => p.CPF).IsRequired().HasColumnType("varchar(14)");

            base.Configure(builder);
        }
    }
}
