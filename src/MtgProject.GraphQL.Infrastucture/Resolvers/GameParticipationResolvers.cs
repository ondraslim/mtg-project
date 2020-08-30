using DAL.Common.Entities;
using MtgProject.GraphQL.Infrastructure.DataLoaders;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MtgProject.GraphQL.Infrastructure.Resolvers
{
    public class GameParticipationResolvers
    {
        public async Task<IEnumerable<GameParticipationEntity>> GetGameParticiptionsByUserAsync(
            UserEntity user,
            GameParticipationByUserIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(user.Id, cancellationToken);
    }
}