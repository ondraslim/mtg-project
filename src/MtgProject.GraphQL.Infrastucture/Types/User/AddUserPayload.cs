using System.Collections.Generic;
using DAL.Common.Entities;
using MtgProject.GraphQL.Infrastructure.Types.Common;

namespace MtgProject.GraphQL.Infrastructure.Types.User
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