using API_Biblioteca_TrabalhoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Biblioteca_TrabalhoFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<Leitores> Leitores { get; set; }
        public DbSet<Nucleos> Nucleos { get; set; }
        public DbSet<Obras> Obras { get; set; }
        public DbSet<Obras_Nucleos> Obras_Nucleos { get; set; }
        public DbSet<Requisicoes> Requisicoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Obras_Nucleos>()
                .HasKey(o => new { o.IDNucleo, o.ISBN });
            modelBuilder.Entity<Requisicoes>()
                .HasKey(o => new { o.ISBN, o.IDNucleo, o.NIF, o.DataRequisicao });
        }
    }
}
