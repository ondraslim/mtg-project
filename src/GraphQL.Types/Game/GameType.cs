using BusinessLayer.DTOs.Games;
using BusinessLayer.Repositories;
using GraphQL.Types.GameParticipation;

namespace GraphQL.Types.Game
{
    public class GameType : ObjectGraphType<GameDto>
    {
        public GameType(GameRepository gameRepository)
        {
            Field(x => x.Id);
            Field(x => x.StartingHp);
            Field(x => x.TurnCount);
            Field<ListGraphType<GameParticipationType>>(nameof(GameParticipation),
                resolve: context => gameRepository.GetAllGameParticipationsOfGame(context.Source.Id));
        }
    }
}