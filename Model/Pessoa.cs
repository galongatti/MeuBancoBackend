using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuBancoBackend.Model
{
    public class Pessoa
    {
        [Key]
        public long? IdPessoa { get; set; }
        public string? PrimeiroNome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public decimal RendaBruta { get; set; }
        public string? Email { get; set; }
        public ICollection<Emprestimo>? Emprestimos { get; set; }
        public string? IdUsuario { get; set; }
        public AspNetUsers Usuario { get; set; }       
    }
}
