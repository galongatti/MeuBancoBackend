using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MeuBancoBackend.Model;

namespace MeuBancoBackend.Context.Configuration
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable(nameof(Pessoa));
            builder.HasKey(x => x.IdPessoa);
            builder.Property(b => b.IdPessoa).HasColumnType("BIGINT").ValueGeneratedOnAdd();
            builder.Property(b => b.PrimeiroNome).HasColumnType("VARCHAR(255)");
            builder.Property(b => b.Sobrenome).HasColumnType("VARCHAR(255)");
            builder.Property(b => b.DataNascimento).HasColumnType("DATE");
            builder.Property(b => b.CPF).HasColumnType("VARCHAR(14)");
            builder.Property(b => b.RendaBruta).HasColumnType("DECIMAL(18,2)");
            builder.HasOne(e => e.Usuario).WithOne(x => x.Pessoa)
            .HasForeignKey<Pessoa>(x => x.IdUsuario).IsRequired(true).HasConstraintName("FK_PESSOA_USUARIO");
        }
    }
}
