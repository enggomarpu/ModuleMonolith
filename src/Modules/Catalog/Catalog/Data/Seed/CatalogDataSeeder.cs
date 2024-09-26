using Microsoft.EntityFrameworkCore;
using Shared.Data.Seed;


namespace Catalog.Data.Seed
{
    public class CatalogDataSeeder : IDataSeeder
    {
        private readonly CatalogDbContext _context;

        public CatalogDataSeeder(CatalogDbContext context)
        {
            _context = context;
        }
        public async Task SeedAllData()
        {

            if(await _context.Products.AnyAsync())
            {
                return;
            }

            await _context.Products.AddRangeAsync(ProductsData.Products);
            await _context.SaveChangesAsync();
           
        }
    }
}
