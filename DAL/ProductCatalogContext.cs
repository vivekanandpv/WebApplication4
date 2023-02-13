using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.DAL
{
    public class ProductCatalogContext : DbContext
    {
        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ProductManufacturer> ProductManufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable(nameof(Product));

            modelBuilder.Entity<Manufacturer>()
                .ToTable(nameof(Manufacturer));

            modelBuilder.Entity<ProductManufacturer>()
                .ToTable(nameof(ProductManufacturer))
                .HasKey(pm => new { pm.ProductId, pm.ManufacturerId });
        }
    }
}
