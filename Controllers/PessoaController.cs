using MeuBancoBackend.DTO;
using MeuBancoBackend.Exceptions;
using MeuBancoBackend.Model;
using MeuBancoBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuBancoBackend.Controllers
{
    public class PessoaController : ControllerBase
    {
        private IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost("CadastrarPessoa")]
        [Authorize]
        public ActionResult CadastrarPessoa([FromBody] NovaPessoaDTO pessoa)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Objeto inválido");
                }

                Pessoa res = _pessoaService.CadastrarPessoa(pessoa);
                return Ok(res);
            }
            catch(CustomException customException)
            {
                return BadRequest(customException.Message);
            }
            catch (DbUpdateException dbUpdateException)
            {
                return BadRequest($"Erro ao salvar {dbUpdateException.Entries}");
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro inesperado");
            }
        }
    }
}
