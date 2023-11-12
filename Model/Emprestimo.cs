using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeuBancoBackend.Model
{
    public class Emprestimo
    {
        [Key]
        public long IdEmprestimo { get; set; }
        public DateTime? DataSolicitacao { get; set; }
        public decimal? ValorSolicitado { get; set; }
        public decimal? ValorAprovado { get; set; }
        public int? NotaSERASA {get;set;}
        public int? ScoreSERASA {get;set;}
        
        [ForeignKey(nameof(Pessoa))]
        public long? IdPessoa { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}