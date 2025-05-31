using DockerComposePotatoDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerComposePotatoDemo.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
    }
}
