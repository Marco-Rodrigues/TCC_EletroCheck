using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace EletroCheck.Models
{
    public class UserPost
    {
        public int Id { get; set; }

        public string UserId { get; set; } // Foreign Key para a tabela "AspNetUsers"
        public IdentityUser UserName { get; set; }

        public string IdentificadorContaConsumo { get; set; } // Foreign Key para a tabela "Posts"
        public CadastroContaConsumo CadastroContaConsumo { get; set; }
    }
}
