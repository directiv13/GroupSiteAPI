using AutoMapper;
using GroupSiteAPI.Dtos;
using GroupSiteAPI.Models;

namespace GroupSiteAPI.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserReadDto>();
        }
    }
}