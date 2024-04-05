using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Contracts
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProject();
        Task<Project> GetProjectID(int id);
        Task DeleteProject(int id);
        Task<Project> AddProject(Project project);
        Task<Project> UpdateProject(Project project);
    }
}
