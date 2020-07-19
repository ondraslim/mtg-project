using BusinessLayer.DTOs.Decks;
using GraphQL.Types.User;

namespace GraphQL.Types.Deck
{
    public class DeckType : ObjectGraphType<DeckDetailDto>
    {
        public DeckType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.UserId);
            Field<UserType>();
        }
    }
}