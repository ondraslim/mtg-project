using System.ComponentModel.DataAnnotations;
using BusinessLayer.DTOs.Common;

namespace BusinessLayer.DTOs.Users
{
    public class UserLoginDto : BaseDto
    {

        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "The field {0} is required")]
        public string Password { get; set; }
    }
}