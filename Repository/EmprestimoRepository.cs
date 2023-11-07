using MeuBancoBackend.Context;
using MeuBancoBackend.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MeuBancoBackend.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {

        private MeuBancoDBContext _emprestimoDBContext;

        public EmprestimoRepository(MeuBancoDBContext emprestimoDBContext) 
        {
            _emprestimoDBContext = emprestimoDBContext;
        }


        public Emprestimo CadastrarEmprestimo(Emprestimo emprestimo)
        {
            EntityEntry<Emprestimo> res = _emprestimoDBContext.Add(emprestimo);
            res.Context.SaveChanges();
            return emprestimo;
        }
    }
}
