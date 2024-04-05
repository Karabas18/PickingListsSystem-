using AutoMapper;
using PickingListsSystem.Dto.Role;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<CreateRoleDto, Role>().ReverseMap();
        }
    }
}
