using Catalog.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Shared.Data;

namespace Catalog
{
	public static class CatalogModule
	{
		public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("PostgresDatabase");
			services.AddDbContext<CatalogDbContext>(options => options.UseNpgsql(connectionString));

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
