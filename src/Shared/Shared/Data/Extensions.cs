
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data.Seed;

namespace Shared.Data
{
	public static class Extensions
	{
		public static IApplicationBuilder UseMigration<T>(this IApplicationBuilder app) where T : DbContext
		{
			MigrateDBAsync<T>(app.ApplicationServices).GetAwaiter().GetResult();
            SeedAsync(app.ApplicationServices).GetAwaiter().GetResult();

            return app;
		}

		private static async Task MigrateDBAsync<T>(IServiceProvider serviceProvider) where T : DbContext
		{
			using var scope = serviceProvider.CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<T>();

			await context.Database.MigrateAsync();

		}

        private static async Task SeedAsync(IServiceProvider serviceProvider)
		{
            using var scope = serviceProvider.CreateScope();
			var seeders = scope.ServiceProvider.GetServices<IDataSeeder>();

			foreach (var seeder in seeders) 
			{ 
				await seeder.SeedAllData();
			}

        }



    }
}
