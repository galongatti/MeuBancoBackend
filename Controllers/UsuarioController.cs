using MeuBancoBackend.DTO;
using MeuBancoBackend.Extension;
using MeuBancoBackend.Model;
using MeuBancoBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MeuBancoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;

        }

        [AllowAnonymous]
        [HttpPost("CadastrarUsuario")]
        public ActionResult CadastrarUsuario([FromBody] NovoUsuarioDTO usuarioDTO)
        {
            try
            {
                IdentityUser res = _usuarioService.CadastrarUsuario(usuarioDTO);

                if (res.Id != string.Empty)
                {
                    UsuarioDTO usuario = new()
                    {
                        Email = res.Email,
                        Id = res.Id
                    };

                    return Ok(usuario);

                }
                else throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao cadastrar");
            }   
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Objeto inválido");

                var result = await _usuarioService.Login(login);

                if (result.Succeeded)
                {
                    LoginResponseDTO token = await _usuarioService.GerarTokenJwt(login.Email);
                    return Ok(token);
                }

                if (result.IsLockedOut)
                {
                    return BadRequest("Usuário bloqueado temporiaramente");
                }

                return BadRequest("Usuário ou Senha incorretos");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao fazer login");
            }
        }

    }
}
