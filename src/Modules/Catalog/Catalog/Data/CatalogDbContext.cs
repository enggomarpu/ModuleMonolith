using Catalog.Data.Configurations;
using Catalog.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data
{
	public class CatalogDbContext : DbContext
	{
        public CatalogDbContext(DbContextOptions options) : base(options)
        {
            
        }

		public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("catalog");
			modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
}
