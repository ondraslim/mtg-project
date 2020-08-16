using DAL.Common.Entities;
using GraphQL.Types.Types.Common;
using System.Collections.Generic;

namespace GraphQL.Types.Types.User
{
    public class AddUserPayload : PayloadBase
    {
        public UserEntity User { get; }

        public AddUserPayload(string? clientMutationId, UserEntity user) : base(clientMutationId)
        {
            User = user;
        }

        public AddUserPayload(IReadOnlyList<UserError> errors, string? clientMutationId, UserEntity user) : base(errors, clientMutationId)
        {
            User = user;
        }
    }
}