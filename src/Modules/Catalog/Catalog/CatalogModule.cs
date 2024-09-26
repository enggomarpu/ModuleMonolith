using Catalog.Data;
using Catalog.Data.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Shared.Data;
using Shared.Data.Seed;

namespace Catalog
{
	public static class CatalogModule
	{
		public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("PostgresDatabase");
			services.AddDbContext<CatalogDbContext>(options => options.UseNpgsql(connectionString));

			services.AddScoped<IDataSeeder, CatalogDataSeeder>();

			return services;
		}

		public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
		{
			// Configure the HTTP request pipeline.

			// 1. Use Api Endpoint services

			// 2. Use Application Use Case services

			// 3. Use Data - Infrastructure services  
			app.UseMigration<CatalogDbContext>();



			return app;
		}

	}
}
