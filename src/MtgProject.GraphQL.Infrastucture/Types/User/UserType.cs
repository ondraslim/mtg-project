using DAL.Common.Entities;
using GraphQL.Types.DataLoader;
using GraphQL.Types.Queries;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.Types.Types.User
{
    /* public class UserType : ObjectType<UserEntity>
     {
         protected override void Configure(IObjectTypeDescriptor<UserEntity> descriptor)
         {
             descriptor
                 .AsNode()
                 .IdField(t => t.Id)
                 .NodeResolver((ctx, id) => ctx.DataLoader<UserByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

             descriptor
                 .Field(t => t.Decks)
                 .ResolveWith<DeckResolvers>(t => t.GetDecksAsync(default!, default!, default))
                 .Name("decks")
                 .UseFiltering()
                 .UseSorting()
                 .UseSelection();
         }

         private class DeckResolvers
         {
             public async Task<IEnumerable<DeckEntity>> GetDecksAsync(
                 UserEntity user,
                 Query query,
                 CancellationToken cancellationToken) =>
                 await query.Decks().LoadAsync(speaker.Id, cancellationToken);
         }
    }*/
}