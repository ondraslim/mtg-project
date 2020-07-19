using AutoMapper;
using BusinessLayer.DTOs.Users;
using DAL.Common.Model;

namespace BusinessLayer.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserDetailDto>();
        }
    }
}