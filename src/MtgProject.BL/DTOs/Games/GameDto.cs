using BusinessLayer.DTOs.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusinessLayer.DTOs.GameParticipations;

namespace BusinessLayer.DTOs.Games
{
    public class GameDto : BaseDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, 99)]
        public int TurnCount { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, 999)]
        public int StartingHp { get; set; }

        public List<GameParticipationCreateDto> GameParticipants { get; set; } = new List<GameParticipationCreateDto>();
    }
}