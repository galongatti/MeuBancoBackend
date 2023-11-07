using MeuBancoBackend.DTO;
using MeuBancoBackend.Model;

namespace MeuBancoBackend.Service
{
    public interface IEmprestimoService
    {
        public Emprestimo CadastrarEmprestimo(NovoEmprestimoDTO emprestimo);
    }
}