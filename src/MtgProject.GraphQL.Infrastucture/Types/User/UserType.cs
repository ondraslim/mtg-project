using DAL.Common.Entities;
using HotChocolate.Types;
using MtgProject.GraphQL.Infrastructure.Resolvers;

namespace MtgProject.GraphQL.Infrastructure.Types.User
{
    public class UserType : ObjectType<UserEntity>
     {
         protected override void Configure(IObjectTypeDescriptor<UserEntity> descriptor)
         {
             descriptor.Field(t => t.PasswordHash).Ignore();
             
             descriptor
                 .Field(t => t.Decks)
                 .Name("decks")
                 .UseFiltering()
                 .UseSorting()
                 .UseSelection();

             descriptor
                 .Field(t => t.GameParticipations)
                 .Name("gameParticipations")
                 .UseFiltering()
                 .UseSorting()
                 .UseSelection();
        }
     }
}