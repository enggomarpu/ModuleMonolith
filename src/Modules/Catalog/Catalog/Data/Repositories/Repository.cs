using Shared.DDD;
using Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Repositories
{
    public class Repository<T, TKey> : DbContextRepository<CatalogDbContext, T, TKey>
    where T : Entity<TKey>, IAggregate
    {
        public Repository(CatalogDbContext dbContext, IDateTimeProvider dateTimeProvider)
            : base(dbContext, dateTimeProvider)
        {
        }
    }
}
