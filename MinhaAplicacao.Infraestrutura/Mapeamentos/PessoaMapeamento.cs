using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAplicacao.Dominio.Entidades;

namespace MinhaAplicacao.Infraestrutura.Mapeamentos
{
    public class PessoaMapeamento : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");

            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(80)");
            builder.Property(p => p.Sexo);
            builder.Property(p => p.Email);
            builder.Property(p => p.DataNascimento).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.Nacionalidade).HasColumnType("varchar(80)");
            builder.Property(p => p.Naturalidade).HasColumnType("varchar(80)");
            builder.Property(p => p.CPF).IsRequired().HasColumnType("varchar(14)");
            builder.Property(p => p.DataHoraCadastro).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.DataHoraModificado).HasColumnType("datetime");
        }
    }
}
