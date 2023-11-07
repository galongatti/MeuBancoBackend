using MeuBancoBackend.DTO;
using MeuBancoBackend.Model;
using MeuBancoBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBancoBackend.Controllers
{
    public class EmprestimoController : ControllerBase
    {
        private IEmprestimoService _emprestimoService;
        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        [HttpPost("CadastrarEmprestimo")]
        [Authorize]
        public ActionResult CadastrarEmprestimo([FromBody] NovoEmprestimoDTO pessoa)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Objeto inválido");
                }

                Emprestimo res = _emprestimoService.CadastrarEmprestimo(pessoa);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
