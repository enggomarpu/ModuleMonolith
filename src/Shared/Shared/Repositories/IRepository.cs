﻿using Microsoft.EntityFrameworkCore;
using Shared.DDD;

using System.Linq.Expressions;


namespace Shared.Repositories
{
	public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
	{
		IUnitOfWork UnitOfWork { get; }

		IQueryable<TEntity> GetQueryableSet();

		Task AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

		Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

		Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

		void Delete(TEntity entity);

		Task<T> FirstOrDefaultAsync<T>(IQueryable<T> query);

		Task<T> SingleOrDefaultAsync<T>(IQueryable<T> query);

		Task<List<T>> ToListAsync<T>(IQueryable<T> query);

		void BulkInsert(IEnumerable<TEntity> entities);

		void BulkInsert(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector);

		void BulkUpdate(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector);

		void BulkMerge(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> idSelector, Expression<Func<TEntity, object>> updateColumnNamesSelector, Expression<Func<TEntity, object>> insertColumnNamesSelector);

		void BulkDelete(IEnumerable<TEntity> entities);

		public async Task<IEnumerable<T>> ListAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}
	}

}
