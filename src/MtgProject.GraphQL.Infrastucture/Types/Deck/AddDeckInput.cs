using System;
using MtgProject.GraphQL.Infrastructure.Types.Common;

namespace MtgProject.GraphQL.Infrastructure.Types.Deck
{
    public class AddDeckInput : InputBase
    {
        public Guid UserId { get; set; }
        public string Name { get; }

        public AddDeckInput(string? clientMutationId, Guid userId, string name) : base(clientMutationId)
        {
            UserId = userId;
            Name = name;
        }
    }
}