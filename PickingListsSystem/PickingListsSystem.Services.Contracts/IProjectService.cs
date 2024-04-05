using PickingListsSystem.Dto.Project;

namespace PickingListsSystem.Services.Contracts
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetProject();
        Task<ProjectDto> GetProjectID(int id);
        Task DeleteProject(int id);
        Task<int> AddProject(CreateProjectDto project);
        Task<int> UpdateProject(ProjectDto project);
    }
}