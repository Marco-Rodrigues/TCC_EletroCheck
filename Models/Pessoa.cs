using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace EletroCheck.Models
{
    [Table("Pessoas")]
    public class Pessoa
    {
        [Key]
        [Required(ErrorMessage= " O CPF deve ser informado")]
        [Display(Name ="CPF")]
        public string CpfId { get; set; }
        [Required(ErrorMessage = " O Nome deve ser informado")]
        [StringLength(50, ErrorMessage = "O Nome deve ser informado")]
        public string Nome { get; set; }
        [Required(ErrorMessage = " O Sobrenome deve ser informado")]
        [StringLength(80, ErrorMessage = "O Sobrenome deve ser informado")]
        public string Sobrenome { get; set; }

        

    }
}
