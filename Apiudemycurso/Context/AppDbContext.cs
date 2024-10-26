using Apiudemycurso.Models;
using Microsoft.EntityFrameworkCore;

namespace Apiudemycurso.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Verificações e mapeamento explícito das entidades
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");

            // Configurações adicionais, se necessário
        }

    }
}
