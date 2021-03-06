﻿using MtgProject.GraphQL.Infrastructure.Types.Common;

namespace MtgProject.GraphQL.Infrastructure.Types.User
{
    public class AddUserInput : InputBase
    {
        public string Name { get; }
        public string Roles { get; }
        public string PasswordHash { get; }

        public AddUserInput(string name, string roles, string passwordHash, string clientMutationId)
            : base(clientMutationId)
        {
            Name = name;
            Roles = roles;
            PasswordHash = passwordHash;
        }
    }
}