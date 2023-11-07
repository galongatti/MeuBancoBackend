using Microsoft.EntityFrameworkCore;
using MeuBancoBackend.Context.Configuration;
using MeuBancoBackend.Model;

namespace MeuBancoBackend.Context
{
    public class MeuBancoDBContext : DbContext
    {

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }

        public MeuBancoDBContext(DbContextOptions<MeuBancoDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<AspNetUsers>().ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
            model.ApplyConfiguration(new PessoaConfiguration());
            model.ApplyConfiguration(new EmprestimoConfiguration());
        }

    }
}
