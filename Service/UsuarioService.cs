using MeuBancoBackend.DTO;
using MeuBancoBackend.Extension;
using Microsoft.AspNetCore.Identity;

namespace MeuBancoBackend.Service
{
    public class UsuarioService : IUsuarioService
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            ) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IdentityUser CadastrarUsuario(NovoUsuarioDTO usuario)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = usuario.Email,
                EmailConfirmed = true,
                UserName = usuario.Email,
            };
            _ = _userManager.CreateAsync(user, usuario.Senha).Result;
            return user;
        }
    }
}
