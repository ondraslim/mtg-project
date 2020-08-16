using BusinessLayer.DTOs.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs.GameParticipations
{
    public class GameParticipationCreateDto : BaseDto
    {
        [Required]
        public Guid GameId { get; set; }

        [Required(ErrorMessage = "The field User is required")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "The field Deck is required")]
        public Guid DeckId { get; set; }

        public Guid StatsId { get; set; }

        public bool IsWinner { get; set; }
    }
}