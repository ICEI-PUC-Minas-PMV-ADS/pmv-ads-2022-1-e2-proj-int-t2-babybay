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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Usuario>()      //  A entidade usuário
        //        .HasMany(c => c.Anuncios)       // Tem muitos anúncios
        //        .WithOne(e => e.Usuario)        // Muitos Anúncios pertence a um usuário
        //        .OnDelete(DeleteBehavior.SetNull); 
        //}

    }
}
