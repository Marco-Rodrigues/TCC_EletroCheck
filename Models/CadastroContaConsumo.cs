using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Xunit.Sdk;

namespace EletroCheck.Models
{
    [Table("CadastroContaConsumo")]
    public class CadastroContaConsumo
    {
        [Key]
        [Required(ErrorMessage = " Identificador da Conta")]
        [StringLength(5, ErrorMessage = "O Identificador deve ser informado")]
        public string IdentificadorContaConsumo { get; set; }

        public string UserName {get; set; } 

        [Required(ErrorMessage = "Url Power BI")]
        [Display(Name = "URL Power BI")]
        public string UrlIframePowerBI{ get; set; }

        [InverseProperty("CadastroContaConsumo")]
        public ICollection<UserPost> UserPosts { get; set; }
        public string UserId { get; internal set; }
    }
}
