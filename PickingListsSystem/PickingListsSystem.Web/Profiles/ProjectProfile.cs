using AutoMapper;
using PickingListsSystem.Dto.Project;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            //CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Project, ProjectDto>()
            .ForMember(dest => dest.Work, opt => opt.MapFrom(src => src.Work)).ReverseMap();

            CreateMap<CreateProjectDto, Project>().ReverseMap();
        }
    }
}
