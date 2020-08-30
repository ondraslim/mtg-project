using System;
using System.Threading.Tasks;
using DAL.Common.Entities;
using DAL.EntityFramework.Data;
using HotChocolate;
using HotChocolate.Types;
using MtgProject.GraphQL.Infrastructure.Extensions;
using MtgProject.GraphQL.Infrastructure.Types.Deck;

namespace MtgProject.GraphQL.Infrastructure.Mutations
{

    [ExtendObjectType(Name = "Mutations")]
    public class DeckMutation
    {
        [UseMtgDbContext]
        public async Task<AddDeckPayload> AddDeckAsync(
            AddDeckInput input,
            [Service] MtgDbContext context)
        {
            var deck = new DeckEntity
            {
                Id = Guid.NewGuid(),
                UserId = input.UserId,
                Name = input.Name,
            };

            await context.Decks.AddAsync(deck);
            await context.SaveChangesAsync();

            return new AddDeckPayload(input.ClientMutationId, deck);
        }
    }
}