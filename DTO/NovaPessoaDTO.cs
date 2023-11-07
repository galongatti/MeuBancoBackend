using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeuBancoBackend.DTO
{
    public class NovaPessoaDTO
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public decimal RendaBruta { get; set; }
        public string IdUsuario { get; set; }
    }
}
