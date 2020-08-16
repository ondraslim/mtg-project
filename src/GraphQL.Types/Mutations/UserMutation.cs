using System;
using System.Threading.Tasks;
using DAL.Common.Entities;
using DAL.EntityFramework.Data;
using GraphQL.Types.Extensions;
using GraphQL.Types.Types.User;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL.Types.Mutations
{

    [ExtendObjectType(Name = "Mutations")]
    public class UserMutation
    {
        [UseMtgDbContext]
        public async Task<AddUserPayload> AddUserAsync(
            AddUserInput input,
            [Service] MtgDbContext context)
        {
            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                RolesString = input.Roles,
                PasswordHash = input.PasswordHash
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return new AddUserPayload(input.ClientMutationId, user);
        }
    }
}