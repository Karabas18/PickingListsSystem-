using AutoMapper;
using PickingListsSystem.Dto.Project;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<CreateProjectDto, Project>().ReverseMap();
        }
    }
}
