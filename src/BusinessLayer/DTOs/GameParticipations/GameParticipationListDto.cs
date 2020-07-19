using BusinessLayer.DTOs.Common;
using BusinessLayer.DTOs.Games;
using System;

namespace BusinessLayer.DTOs.GameParticipations
{
    public class GameParticipationListDto : BaseDto
    {
        public Guid GameId { get; set; }
        public GameListDto Game { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public Guid DeckId { get; set; }
        public string DeckName { get; set; }
        public bool IsWinner { get; set; }

    }
}