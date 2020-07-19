using BusinessLayer.DTOs.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs.Decks
{
    public class DeckCreateDto : BaseDto
    {
        [Required(ErrorMessage = "The field {0} is required")] 
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name is required with minimum length of 5 characters")]
        public string Name { get; set; }

    }
}