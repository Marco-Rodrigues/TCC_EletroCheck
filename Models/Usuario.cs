using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace EletroCheck.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = " O e-mail deve ser informado")]
        [Display(Name = "E-mail")]
        public string emailId { get; set; }

        [Required(ErrorMessage = " O Telefone deve ser informado")]
        [Display(Name = "Celular")]
        public int telefone { get; set; }

        [Required(ErrorMessage = " A Senha deverá ser informada")]
        [MinLength(4,ErrorMessage = "A senha não poderá ser menor que 4 digitos" )]
        [MaxLength(6, ErrorMessage = "A senha não poderá ser maior que 6 digitos")]
        [Display(Name = "Senha")]
        public string senha { get; set; }
        public bool Administrador { get; set; }

        // Definindo a relação entre as duas entidades, onde será 1 para 1
        [ForeignKey("CpfId")]
        public virtual Pessoa Pessoa { get; set; }


    }
}
