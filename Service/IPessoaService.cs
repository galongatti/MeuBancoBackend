using MeuBancoBackend.DTO;
using MeuBancoBackend.Model;

namespace MeuBancoBackend.Service
{
    public interface IPessoaService
    {
        public Pessoa CadastrarPessoa(NovaPessoaDTO pessoa);
       
    }
}
