using MeuBancoBackend.Extension;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeuBancoBackend.Context
{
    public class UsuarioDBContext : IdentityDbContext<IdentityUser>
    {
        public UsuarioDBContext(DbContextOptions<UsuarioDBContext> options) : base(options) { }

    }

}
