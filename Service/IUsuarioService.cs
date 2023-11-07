using MeuBancoBackend.DTO;
using MeuBancoBackend.Model;
using Microsoft.AspNetCore.Identity;

namespace MeuBancoBackend.Service
{
    public interface IUsuarioService
    {
        IdentityUser CadastrarUsuario(NovoUsuarioDTO usuario);
        IdentityUser AtualizarUsuario(IdentityUser usuario);
        IdentityUser BuscarUsuarioPeloId(string id);
        Task<SignInResult> Login(LoginDTO usuario);
        Task<LoginResponseDTO> GerarTokenJwt(string email);
    }
}
