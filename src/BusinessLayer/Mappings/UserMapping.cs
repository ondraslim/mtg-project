using AutoMapper;
using BusinessLayer.DTOs.Users;
using DAL.Common.Entities;

namespace BusinessLayer.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserCreateDto, UserEntity>();
            CreateMap<UserUpdateDto, UserEntity>();
            CreateMap<UserLoginDto, UserEntity>();
            CreateMap<UserEntity, UserDetailDto>();
        }
    }
}