using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace EletroCheck.Context
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string UrlPowerBi { get; set; }

        [Required(ErrorMessage = "Informe o seu Primeiro Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Informe o seu Sobrenome")]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }
                
        [Display(Name = "Usuário Administrador")]
        public bool UsuárioAdministrador { get; set; }

    }
}
