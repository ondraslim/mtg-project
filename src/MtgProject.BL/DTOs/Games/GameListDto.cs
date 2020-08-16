using BusinessLayer.DTOs.Common;

namespace BusinessLayer.DTOs.Games
{
    public class GameListDto : BaseDto
    {
        public int TurnCount { get; set; }

        public int StartingHp { get; set; }

        public string Winner { get; set; }
    }
}