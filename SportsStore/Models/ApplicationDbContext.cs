using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;


// Контекст базы данных, здесь определяется какие модели будут созданы в базе данных
namespace SportsStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sport_shop;Username=dev;Password=dev");
        // }
    }
}