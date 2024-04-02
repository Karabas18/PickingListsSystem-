using AutoMapper;
using PickingListsSystem.Dto.WorkType;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class WorkTypeProfile : Profile
    {
        public WorkTypeProfile()
        {
            CreateMap<WorkType, WorkTypeDto>().ReverseMap();
            CreateMap<CreateWorkTypeDto, WorkType>().ReverseMap();
        }
    }
}
