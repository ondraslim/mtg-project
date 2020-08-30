using DAL.Common.Entities;
using MtgProject.GraphQL.Infrastructure.DataLoaders;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MtgProject.GraphQL.Infrastructure.Resolvers
{
    public class DeckResolvers
    {
        public async Task<IEnumerable<DeckEntity>> GetDecksByUserAsync(
            UserEntity user,
            DeckByUserIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(user.Id, cancellationToken);
    }
}