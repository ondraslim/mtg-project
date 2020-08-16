using DAL.Common.Entities;
using DAL.EntityFramework.Data;
using GraphQL.Types.DataLoader;
using GraphQL.Types.Extensions;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.Types.Queries
{

    [ExtendObjectType(Name = "Queries")]
    public class Query
    {
       
        [UseFirstOrDefault]
        [UseSelection]
        [UseMtgDbContext]
        public IQueryable<UserEntity> User([Service] MtgDbContext context, Guid id) =>
            context.Users.Where(t => t.Id == id);


        [UseMtgDbContext]
        public Task<UserEntity> UserLoader(
            Guid userId,
            UserByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(userId, cancellationToken);


        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        [UseMtgDbContext]
        public IQueryable<UserEntity> Users([Service] MtgDbContext context) =>
            context.Users;


        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        [UseMtgDbContext]
        public IQueryable<DeckEntity> Decks([Service] MtgDbContext context) =>
            context.Decks;


        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        [UseMtgDbContext]
        public IQueryable<GameEntity> Games([Service] MtgDbContext context) =>
            context.Games;

    }
}