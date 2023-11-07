using MeuBancoBackend.Context.Configuration;
using MeuBancoBackend.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeuBancoBackend.Context
{
    public class UsuarioDBContext : IdentityDbContext<IdentityUser>
    {
        private readonly DbContextOptions _options;

        public UsuarioDBContext(DbContextOptions<UsuarioDBContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }

    }

}
