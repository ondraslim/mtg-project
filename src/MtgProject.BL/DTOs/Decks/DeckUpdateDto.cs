using BusinessLayer.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs.Decks
{
    public class DeckUpdateDto : BaseDto
    {

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name is required with minimum length of 5 characters")]
        public string Name { get; set; }
    }
}