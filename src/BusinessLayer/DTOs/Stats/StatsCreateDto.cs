using BusinessLayer.DTOs.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs.Stats
{
    public class StatsCreateDto : BaseDto
    {
        public Guid GameParticipationId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(0, 9999)]
        public int DamageDealt { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(0, 9999)]
        public int DamageReceived { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(0, 50)]
        public int Kills { get; set; }
    }
}