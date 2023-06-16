using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace EletroCheck.ViewsModels

{
    [Authorize]
    public class LoginViewModel
    {
        [Key]
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Informe o seu usuário")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "URL do Power BI")]
        public string IframePowerBi { get; set; }

    }
}
