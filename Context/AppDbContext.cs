using EletroCheck.Models;
using EletroCheck.ViewsModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletroCheck.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    //public class AppDbContext : IdentityDbContext<CadastroViewModel>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }

        // public DbSet<CadastroContaConsumo> CadastroContaConsumo { get; set; }
        //public DbSet<UserPost> UserPost  { get; set; }


        // Neste momento estou definindo quais são as classes que serão mapeadas

        //
        //public DbSet<Usuario> Usuarios{ get; set; }*@
    }

    internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }
    }
}
