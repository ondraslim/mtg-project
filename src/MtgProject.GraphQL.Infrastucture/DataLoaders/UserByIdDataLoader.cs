using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Common.Entities;
using DAL.EntityFramework.Data;
using HotChocolate.DataLoader;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace MtgProject.GraphQL.Infrastructure.DataLoaders
{
    public class UserByIdDataLoader : BatchDataLoader<Guid, UserEntity>
    {
        // TODO: uncomment when db context pooling with logging enabled
        //private readonly DbContextPool<MtgDbContext> _dbContextPool;
        private readonly MtgDbContext dbContext;

        public UserByIdDataLoader(MtgDbContext dbContextPool)
        {
            dbContext = dbContextPool ?? throw new ArgumentNullException(nameof(dbContextPool));
        }

        [UseSelection]
        [UseFiltering]
        protected override async Task<IReadOnlyDictionary<Guid, UserEntity>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            //TODO: add includes/filters https://hotchocolate.io/docs/filters
            return await dbContext.Users.Where(s => keys.Contains(s.Id)).ToDictionaryAsync(t => t.Id, cancellationToken);
            // MtgDbContext dbContext = _dbContextPool.Rent();
            // try
            // {
            //     return await dbContext.Users
            //         .Where(s => keys.Contains(s.Id))
            //         .ToDictionaryAsync(t => t.Id, cancellationToken);
            // }
            // finally
            // {
            //     _dbContextPool.Return(dbContext);
            // }
        }
    }
}