using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MeuBancoBackend.Model;

namespace MeuBancoBackend.Context.Configuration
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable(nameof(Emprestimo));
            builder.Property(e => e.ValorAprovado).HasColumnType("DECIMAL(18,2)");
            builder.Property(e => e.DataSolicitacao).HasColumnType("DATETIME");
            builder.HasKey(e => e.IdEmprestimo);
            builder.Property(e => e.IdEmprestimo).HasColumnType("BIGINT").ValueGeneratedOnAdd();
            builder.Property(e => e.ValorSolicitado).HasColumnType("DECIMAL(18,2)");
            builder.Property(e => e.PercentualSalario).HasColumnType("DECIMAL(18,2)");
            builder.Property(e => e.NotaSalario).HasColumnType("INT");
            builder.Property(e => e.IdPessoa).HasColumnType("BIGINT");
            builder.HasOne(e => e.Pessoa).WithMany(e => e.Emprestimos)
                .HasForeignKey(x => x.IdPessoa).IsRequired(true).HasConstraintName("FK_EMPRESTIMO_PESSOA");
        }
    }
}
