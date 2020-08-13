using BusinessLayer.Repositories;
using GraphQL.Types;
using GraphQL.Types.Deck;
using System;

namespace GraphQL.API.Queries
{
    public class DeckQuery : ObjectGraphType
    {
        public DeckQuery(DeckRepository deckRepository)
        {
            Field<ListGraphType<DeckType>>(
                "decks",
                resolve: context => deckRepository.GetAllAsync());

            Field<DeckType>(
                "deck",
                arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
                resolve: context => deckRepository.GetByIdAsync(context.GetArgument<Guid>("id")));

            Field<ListGraphType<DeckType>>(
                "decksOfUser",
                arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "userId" }),
                resolve: context => deckRepository.GetDecksOfUserAsync(context.GetArgument<Guid>("userId")));
        }
    }
}