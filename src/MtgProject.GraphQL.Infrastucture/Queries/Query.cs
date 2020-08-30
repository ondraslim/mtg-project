using DAL.Common.Entities;
using DAL.EntityFramework.Data;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using MtgProject.GraphQL.Infrastructure.Extensions;
using System.Linq;

namespace MtgProject.GraphQL.Infrastructure.Queries
{

    [ExtendObjectType(Name = "Queries")]
    public class Query
    {
        
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

        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        [UseMtgDbContext]
        public IQueryable<StatsEntity> Stats([Service] MtgDbContext context) =>
            context.Stats;

    }
}