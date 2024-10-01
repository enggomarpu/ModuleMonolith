using Microsoft.EntityFrameworkCore;
using Shared.DDD;

using System.Linq.Expressions;


namespace Shared.Repositories
{
	public interface IRepository<T> where T : Entity<Guid>
	{
		Task<T> GetByIdAsync(int id);
		Task<IReadOnlyList<T>> ListAllAsync();
		//Task<T> GetEntityWithSpec(ISpecification<T> spec);
		//Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
		//Task<int> CountAsync(ISpecification<T> spec);
	}
}
