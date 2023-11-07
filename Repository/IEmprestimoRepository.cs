using MeuBancoBackend.Model;

namespace MeuBancoBackend.Repository
{
    public interface IEmprestimoRepository
    {
        public Emprestimo CadastrarEmprestimo(Emprestimo pessoa);
    }
}
