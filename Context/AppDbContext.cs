using EletroCheck.Models;
using Microsoft.EntityFrameworkCore;

namespace EletroCheck.Context
{
    public class AppDbContext : DbContext
    {
        public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    

        // Neste momento estou definindo quais são as classes que serão mapeadas
        
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Usuario> Usuarios{ get; set; }
    }
}
