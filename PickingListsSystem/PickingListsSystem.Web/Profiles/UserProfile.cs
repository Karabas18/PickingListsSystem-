using AutoMapper;
using PickingListsSystem.Dto.User;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, User>().ReverseMap();
        }
    }
}
