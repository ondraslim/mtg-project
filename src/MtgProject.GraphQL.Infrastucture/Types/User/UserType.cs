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
                 //.Resolver(ctx => ctx.Service<MtgDbContext>().Decks.Where(d => ctx.Parent<UserEntity>().Id == d.UserId))
                 .ResolveWith<DeckResolvers>(d => d.GetDecksByUserAsync(default!, default!, default))
                 .Name("decks")
                 .UseFiltering()
                 .UseSorting()
                 .UseSelection();

             //TODO: add resolver with data loader
             descriptor
                 .Field(t => t.GameParticipations)
                 //.Resolver(ctx => ctx.Service<MtgDbContext>().GameParticipations.Where(d => ctx.Parent<UserEntity>().Id == d.UserId))
                 .ResolveWith<GameParticipationResolvers>(d => d.GetGameParticiptionsByUserAsync(default!, default!, default))
                 .Name("gameParticipations")
                 .UseFiltering()
                 .UseSorting()
                 .UseSelection();
        }
     }
}