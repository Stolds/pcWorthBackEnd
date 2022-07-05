
using PcWorth.Models;
using Microsoft.EntityFrameworkCore;

namespace PcWorth.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {

        }
        public DbSet<Product> Product {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var product_model = modelBuilder.Entity<Product>();
            product_model.ToTable("tb_product");
            product_model.HasKey(x => x.Id);
            product_model.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            product_model.Property(x => x.Name).HasColumnName("name").IsRequired();
            product_model.Property(x => x.Price).HasColumnName("price").IsRequired();
        }
    }
}