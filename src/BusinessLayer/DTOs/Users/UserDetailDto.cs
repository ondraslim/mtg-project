using BusinessLayer.DTOs.Common;

namespace BusinessLayer.DTOs.Users
{
    public class UserDetailDto : BaseDto
    {
        public string Name { get; set; }

        public string[] Roles { get; set; }
    }
}
