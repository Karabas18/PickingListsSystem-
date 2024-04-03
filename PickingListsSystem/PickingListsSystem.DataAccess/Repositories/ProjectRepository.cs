// методы для работы с баззой данных 
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(PlsDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Project>> GetProject()
        {
            var result = await _dbContext.Project.ToListAsync();
            return result;
        }

        public async Task<Project> GetProjectID(int id)
        {
            var result = await _dbContext.Project.FirstOrDefaultAsync(project => project.Id == id);
            return result;
        }

        public async Task DeleteProject(int id)
        {
            var result = await _dbContext.Project.FindAsync(id);

            if (result != null)
            {
                _dbContext.Project.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Project> AddProject(Project project)
        {
            _dbContext.Project.Add(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateProject(Project project)
        {
            _dbContext.Project.Update(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }
    }
}
