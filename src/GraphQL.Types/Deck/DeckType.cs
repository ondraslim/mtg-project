using BusinessLayer.DTOs.Decks;
using BusinessLayer.Repositories;
using GraphQL.Types.User;

namespace GraphQL.Types.Deck
{
    public class DeckType : ObjectGraphType<DeckDetailDto>
    {
        private readonly DeckRepository deckRepository;

        //TODO: query
        public DeckType(DeckRepository deckRepository)
        {
            this.deckRepository = deckRepository;

            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.UserId);
            Field<UserType>();
            /*Field<ListGraphType<GameListDto>>("games",
                context => deckRepository.get
                )
            */
        }
    }
}