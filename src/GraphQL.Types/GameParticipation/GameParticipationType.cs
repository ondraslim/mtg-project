using BusinessLayer.DTOs.GameParticipations;
using GraphQL.Types.Deck;
using GraphQL.Types.User;

namespace GraphQL.Types.GameParticipation
{
    public class GameParticipationType : ObjectGraphType<GameParticipationListDto>
    {
        public GameParticipationType()
        {
            Field(x => x.GameId);
            Field(x => x.DeckId);
            Field<DeckType>();
            Field(x => x.UserId);
            Field<UserType>();
            Field(x => x);
            //Field<StatsType>(); // TODO: allow more complex types
            Field(x => x.IsWinner);
        }
    }
}