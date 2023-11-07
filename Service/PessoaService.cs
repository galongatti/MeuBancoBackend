using MeuBancoBackend.DTO;
using MeuBancoBackend.Exceptions;
using MeuBancoBackend.Model;
using MeuBancoBackend.Model;
using MeuBancoBackend.Repository;
using Microsoft.AspNetCore.Identity;

namespace MeuBancoBackend.Service
{
    public class PessoaService : IPessoaService
    {
        private IPessoaRepository _pessoaRepository;
        private IUsuarioService _usuarioService;

        public PessoaService(IPessoaRepository pessoaRepository, IUsuarioService usuarioService)
        {
            _pessoaRepository = pessoaRepository;
            _usuarioService = usuarioService;
        }

        public Pessoa CadastrarPessoa(NovaPessoaDTO pessoaDTO)
        {

           
            IdentityUser aspNetUsers = _usuarioService.BuscarUsuarioPeloId(pessoaDTO.IdUsuario);

            if(aspNetUsers.Id == string.Empty) throw new CustomException("Usuário não encontrado");

            Pessoa res = new();

            if (aspNetUsers.Id != string.Empty)
            {
                Pessoa pessoa = new()
                {
                    CPF = pessoaDTO.CPF,
                    DataNascimento = pessoaDTO.DataNascimento,
                    PrimeiroNome = pessoaDTO.PrimeiroNome,
                    Sobrenome = pessoaDTO.Sobrenome,
                    RendaBruta = pessoaDTO.RendaBruta,
                    RG = pessoaDTO.RG,
                    IdUsuario = aspNetUsers.Id
                };
                res = _pessoaRepository.CadastarPessoa(pessoa);
            }
        
            return res;
        }
    }
}
