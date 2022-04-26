using Microsoft.EntityFrameworkCore;
using app_babybay.Models;

namespace app_babybay.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<GuardaRoupa> GuardaRoupas { get; set; }
    }
}
