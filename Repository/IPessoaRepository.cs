using MeuBancoBackend.Model;

namespace MeuBancoBackend.Repository
{
    public interface IPessoaRepository
    {
        public Pessoa CadastarPessoa(Pessoa pessoa);
    }
}
