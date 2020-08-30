using DAL.Common.Entities;
using DAL.EntityFramework.Data;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MtgProject.GraphQL.Infrastructure.DataLoaders
{
    public class GameParticipationByUserIdDataLoader : GroupedDataLoader<Guid, GameParticipationEntity>
    {
        private readonly MtgDbContext db;

        public GameParticipationByUserIdDataLoader(MtgDbContext db)
        {
            this.db = db;
        }


        protected override async Task<ILookup<Guid, GameParticipationEntity>> LoadGroupedBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            return db.GameParticipations
                .Where(s => keys.Contains(s.UserId))
                .Include(s => s.StatsEntity)
                .Include(s => s.GameEntity)
                .ToLookup(t => t.UserId, t => t);
        }
    }
}