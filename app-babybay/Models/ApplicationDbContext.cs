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
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Troca> Trocas { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Suporte> Suportes { get; set; }
        public DbSet<Image> Image { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(ImageMap.Create());
        }

    }
}

