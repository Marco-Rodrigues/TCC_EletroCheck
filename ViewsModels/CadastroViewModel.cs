
using EletroCheck.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace EletroCheck.ViewsModels
{
    public class CadastroViewModel : IdentityUser


    {
        
        [Required(ErrorMessage = "Informe o seu Primeiro Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Informe o seu Sobrenome")]
        [Display (Name = "Sobrenome")]
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


        //public string UserId { get; set; } // Foreign Key para a tabela "AspNetUsers"
        //public CadastroViewModel UserName { get; set; }
        //public IdentityUser UserName { get; set; }


        [Required(ErrorMessage = " Identificador da Conta")]
        [StringLength(5, ErrorMessage = "O Identificador deve ser informado")]
        public string IdentificadorContaConsumo { get; set; } // Foreign Key para a tabela "Posts"
        public CadastroContaConsumo CadastroContaConsumo { get; set; }

        [Required(ErrorMessage = "Url Power BI")]
        [Display(Name = "URL Power BI")]
        public string UrlIframePowerBI { get; set; }


    }
}
