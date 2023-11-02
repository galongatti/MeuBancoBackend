using MeuBancoBackend.DTO;
using MeuBancoBackend.Extension;
using Microsoft.AspNetCore.Identity;

namespace MeuBancoBackend.Service
{
    public interface IUsuarioService
    {
        IdentityUser CadastrarUsuario(NovoUsuarioDTO usuario);
        Task<SignInResult> Login(LoginDTO usuario);
        Task<LoginResponseDTO> GerarTokenJwt(string email);
    }
}
