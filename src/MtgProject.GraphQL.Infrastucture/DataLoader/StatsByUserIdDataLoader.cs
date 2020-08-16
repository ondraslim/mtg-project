using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Common.Entities;
using DAL.EntityFramework.Data;
using HotChocolate.DataLoader;

namespace GraphQL.Types.DataLoader
{
    public class StatsByUserIdDataLoader : GroupedDataLoader<Guid, StatsEntity>
    {
        // TODO context to pool
        private readonly MtgDbContext _dbContextPool;

            public StatsByUserIdDataLoader(MtgDbContext dbContextPool)
            {
                _dbContextPool = dbContextPool ?? throw new ArgumentNullException(nameof(dbContextPool));
            }

            protected override async Task<ILookup<Guid, StatsEntity>> LoadGroupedBatchAsync(
                IReadOnlyList<Guid> keys,
                CancellationToken cancellationToken)
            {

                return null!;

            // TODO: implement
            // https://github.com/michaelstaib/graphql-workshop/blob/master/docs/2-building-out-the-graphql-server.md#fluent-type-configurations
            /*
            ApplicationDbContext dbContext = _dbContextPool.Rent();
            try
            {
                List<SessionSpeaker> speakers = await dbContext.Speakers
                    .Where(speaker => keys.Contains(speaker.Id))
                    .Include(speaker => speaker.SessionSpeakers)
                    .SelectMany(speaker => speaker.SessionSpeakers)
                    .Include(sessionSpeaker => sessionSpeaker.Session)
                    .ToListAsync();

                return speakers
                    .Where(t => t.Session is { })
                    .ToLookup(t => t.SpeakerId, t => t.Session!);
            }
            finally
            {
                _dbContextPool.Return(dbContext);
            }*/
        }
    }
    
}