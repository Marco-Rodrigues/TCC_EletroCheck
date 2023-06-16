using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EletroCheck.Context
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string UrlPowerBi { get; set; }

    }
}
