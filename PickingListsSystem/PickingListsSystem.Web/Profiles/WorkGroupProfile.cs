using AutoMapper;
using PickingListsSystem.Dto.WorkGroup;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class WorkGroupProfile : Profile
    {
        public WorkGroupProfile()
        {
            CreateMap<WorkGroup, WorkGroupDto>().ReverseMap();
            CreateMap<CreateWorkGroupDto, WorkGroup>().ReverseMap();
        }
    }
}
