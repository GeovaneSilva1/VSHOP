using Microsoft.EntityFrameworkCore;
using VShop.ProdutoApi.Models;

namespace VShop.ProdutoApi.Context;
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias {get;set;}
        public DbSet<Produto> Produtos {get;set;}

    //Fluent API
    protected override void OnModelCreating(ModelBuilder mb)
    {
        //Categoria
        mb.Entity<Categoria>().HasKey(c => c.CategoriaId);

        mb.Entity<Categoria>().
        Property(c => c.Nome).
        HasMaxLength(100).
        IsRequired();

        //Produto
        mb.Entity<Produto>().
        Property(c => c.Nome).
        HasMaxLength(100).
        IsRequired();

        mb.Entity<Produto>().
        Property(c => c.Descricao).
        HasMaxLength(255).
        IsRequired();

        mb.Entity<Produto>().
        Property(c => c.ImageUrl).
        HasMaxLength(255).
        IsRequired();
        
        mb.Entity<Produto>().
        Property(c => c.Preco).
        HasPrecision(12, 2);
        
        mb.Entity<Categoria>().
        HasMany(g => g.Produtos).
        WithOne(c => c.Categoria).
        IsRequired().
        OnDelete(DeleteBehavior.Cascade);

        mb.Entity<Categoria>().
        HasData(
            new Categoria
            {
                CategoriaId = 1,
                Nome = "Material Escolar",
            },
            new Categoria 
            {
                CategoriaId = 2,
                Nome = "Acessórios",
            }
        );
        
    }

}