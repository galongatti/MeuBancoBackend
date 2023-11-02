using MeuBancoBackend.DTO;
using MeuBancoBackend.Extension;
using MeuBancoBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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


    }
}
