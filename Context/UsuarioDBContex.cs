using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeuBancoBackend.Context
{
    public class UsuarioDBContex : IdentityDbContext<IdentityUser>
    {
        public UsuarioDBContex(DbContextOptions<UsuarioDBContex> options) : base(options) { }
    }
}
