using MeuBancoBackend.DTO;
using MeuBancoBackend.Model;
using MeuBancoBackend.Repository;

namespace MeuBancoBackend.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private IEmprestimoRepository _emprestimoRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public Emprestimo CadastrarEmprestimo(NovoEmprestimoDTO novoEmprestimo)
        {

            Emprestimo emprestimo = new()
            {
                DataSolicitacao = DateTime.Now,
                IdPessoa = novoEmprestimo.IdPessoa,
                ValorAprovado = null,
                ValorSolicitado = novoEmprestimo.ValorSolicitado
            };

            emprestimo = _emprestimoRepository.CadastrarEmprestimo(emprestimo);

            AnalisarEmprestimo(emprestimo);

            return emprestimo;
        }

        public void AnalisarEmprestimo(Emprestimo emprestimo)
        {
            //código do producer enviando mensagem para os consumer
        }
    }
}