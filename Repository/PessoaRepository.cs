using MeuBancoBackend.Context;
using MeuBancoBackend.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MeuBancoBackend.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private MeuBancoDBContext _pessoaDBContext;

        public PessoaRepository(MeuBancoDBContext pessoaDBContext) 
        {
            _pessoaDBContext = pessoaDBContext;
        }

        public Pessoa CadastarPessoa(Pessoa pessoa)
        {
            EntityEntry<Pessoa> res = _pessoaDBContext.Add(pessoa);
            res.Context.SaveChanges();
            return pessoa;
        }
    }
}
