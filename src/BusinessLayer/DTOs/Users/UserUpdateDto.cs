using BusinessLayer.DTOs.Common;

namespace BusinessLayer.DTOs.Users
{
    public class UserUpdateDto : BaseDto
    {
        public string Password { get; set; }

        public string PasswordHash { get; set; }
    }
}