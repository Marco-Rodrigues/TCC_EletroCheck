using EletroCheck.Context;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace EletroCheck.ViewsModels
{
    public class RegisterViewModel


    {
        //[Required(ErrorMessage = "Informe o seu Primeiro Nome")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Informe o seu Sobrenome")]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Informe o seu Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a sua senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }

    }
}
