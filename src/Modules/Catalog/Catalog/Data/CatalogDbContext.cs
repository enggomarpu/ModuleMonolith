using Catalog.Data.Configurations;
using Catalog.Products.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Repositories;

namespace Catalog.Data
{
	public class CatalogDbContext : DbContextUnitOfWork<CatalogDbContext>
	{
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
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
