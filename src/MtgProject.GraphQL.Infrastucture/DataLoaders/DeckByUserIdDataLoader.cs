using DAL.Common.Entities;
using DAL.EntityFramework.Data;
using HotChocolate.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MtgProject.GraphQL.Infrastructure.DataLoaders
{
    public class DeckByUserIdDataLoader : GroupedDataLoader<Guid, DeckEntity>
    {
        private readonly MtgDbContext db;

        public DeckByUserIdDataLoader(MtgDbContext db)
        {
            this.db = db;
        }

        protected override async Task<ILookup<Guid, DeckEntity>> LoadGroupedBatchAsync(
            IReadOnlyList<Guid> keys, 
            CancellationToken cancellationToken)
        {
            return db.Decks
                .Where(s => keys.Contains(s.UserId))
                .ToLookup(t => t.UserId, t => t);
        }
    }
}