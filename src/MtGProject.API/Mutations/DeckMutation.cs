using AutoMapper;
using BusinessLayer.DTOs.Decks;
using BusinessLayer.Repositories;
using DAL.Common.Model;
using GraphQL.Types;
using GraphQL.Types.Deck;

namespace GraphQL.API.Mutations
{
    public class DeckMutation : ObjectGraphType
    {
        public DeckMutation(DeckRepository deckRepository, IMapper mapper)
        {
            Name = "AddDeckMutation";

            Field<DeckType>(
                "addDeck",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<DeckInputType>> { Name = "deck" }),
                resolve: context =>
                {
                    var deck = context.GetArgument<DeckCreateDto>("deck");
                    return deckRepository.Create(mapper.Map<DeckCreateDto, Deck>(deck)); 
                    // TODO: should not reference DAL! add service/facade with conversion
                });
        }
    }
}