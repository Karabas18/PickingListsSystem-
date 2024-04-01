using AutoMapper;
using PickingListsSystem.Dto.Work;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkDto>().ReverseMap();
            CreateMap<CreateWorkDto, Work>().ReverseMap();
        }
    }
}
