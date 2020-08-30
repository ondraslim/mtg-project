using System.Collections.Generic;
using DAL.Common.Entities;
using MtgProject.GraphQL.Infrastructure.Types.Common;

namespace MtgProject.GraphQL.Infrastructure.Types.Deck
{
    public class AddDeckPayload : PayloadBase
    {
        public DeckEntity Deck { get; }
        
        public AddDeckPayload(string? clientMutationId, DeckEntity deck) 
            : base(clientMutationId)
        {
            Deck = deck;
        }

        public AddDeckPayload(IReadOnlyList<UserError> errors, string? clientMutationId, DeckEntity deck)
            : base(errors, clientMutationId)
        {
            Deck = deck;
        }
    }
}