using DAL.Common.Entities;
using DAL.EntityFramework.Data;
using GraphQL.Types.User;
using HotChocolate;
using System;
using System.Threading.Tasks;

namespace GraphQL.API.Mutations
{
    public class UserMutation
    {
        public async Task<AddUserPayload> AddUserAsync(
            AddUserInput input,
            [Service] MtgDbContext context)
        {
            var user = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                RolesString = input.Roles,
                PasswordHash = input.PasswordHash
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return new AddUserPayload(user, input.ClientMutationId);
        }
    }
}