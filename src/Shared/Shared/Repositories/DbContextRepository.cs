using Microsoft.EntityFrameworkCore;
using Shared.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class DbContextRepository<TDbContext, TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>, IAggregate
    where TDbContext : DbContext, IUnitOfWork
    {
        private readonly TDbContext _dbContext;
        //private readonly IDateTimeProvider _dateTimeProvider;

        protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public DbContextRepository(TDbContext dbContext, IDateTimeProvider dateTimeProvider)
        {
            _dbContext = dbContext;
            //_dateTimeProvider = dateTimeProvider;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            //entity.CreatedDateTime = _dateTimeProvider.OffsetNow;
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            //entity.UpdatedDateTime = _dateTimeProvider.OffsetNow;
            return Task.CompletedTask;
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<TEntity> GetQueryableSet()
        {
            return _dbContext.Set<TEntity>();
        }

        public Task<T1> FirstOrDefaultAsync<T1>(IQueryable<T1> query)
        {
            return query.FirstOrDefaultAsync();
        }

        public Task<T1> SingleOrDefaultAsync<T1>(IQueryable<T1> query)
        {
            return query.SingleOrDefaultAsync();
        }

        public Task<List<T1>> ToListAsync<T1>(IQueryable<T1> query)
        {
            return query.ToListAsync();
        }

        
        public void SetRowVersion(TEntity entity, byte[] version)
        {
            _dbContext.Entry(entity).OriginalValues[nameof(entity.RowVersion)] = version;
        }

        public bool IsDbUpdateConcurrencyException(Exception ex)
        {
            return ex is DbUpdateConcurrencyException;
        }


        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }









    }
}
