using DAL.Common.Entities;
using DAL.EntityFramework.Data;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System;
using System.Linq;

namespace GraphQL.API.Queries
{
    public class Query
    {
        [UseFirstOrDefault]
        [UseSelection]
        public IQueryable<UserEntity> GetUserById([Service] MtgDbContext context, Guid userId) =>
            context.Users.Where(t => t.Id == userId);

        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<UserEntity> GetUsers([Service] MtgDbContext context) =>
            context.Users;

        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<DeckEntity> GetDecks([Service] MtgDbContext context) =>
            context.Decks;

        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<GameEntity> GetGames([Service] MtgDbContext context) =>
            context.Games;
    }
}