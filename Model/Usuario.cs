using MeuBancoBackend.Model;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuBancoBackend.Model
{
    public partial class AspNetUsers : IdentityUser
    {
        public Pessoa Pessoa { get; set; }
    }
}
