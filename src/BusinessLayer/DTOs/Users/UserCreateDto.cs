using System.ComponentModel.DataAnnotations;
using BusinessLayer.DTOs.Common;

namespace BusinessLayer.DTOs.Users
{
    public class UserCreateDto : BaseDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name is required with minimum length of 5 characters")]
        public string Name { get; set; }

        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password is required with minimum length of 8 characters")]
        public string Password { get; set; }
    }
}
