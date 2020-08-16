using DAL.Common.Entities;
using GraphQL.Types.Types.Common;
using System.Collections.Generic;

namespace GraphQL.Types.Types.Deck
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