using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Repositories
{
    public class WorkGroupRepository : BaseRepository, IWorkGroupRepository
    {
        public WorkGroupRepository(PlsDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<WorkGroup>> GetWorkGroup()
        {
            var result = await _dbContext.WorkGroup.ToListAsync();
            return result;
        }

        public async Task<WorkGroup> GetWorkGroupID(int id)
        {
            var result = await _dbContext.WorkGroup.FirstOrDefaultAsync(workGroup => workGroup.Id == id);
            return result;
        }

        public async Task DeleteWorkGroup(int id)
        {
            var result = await _dbContext.WorkGroup.FindAsync(id);

            if (result != null)
            {
                _dbContext.WorkGroup.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<WorkGroup> AddWorkGroup(WorkGroup workGroup)
        {
            _dbContext.WorkGroup.Add(workGroup);
            await _dbContext.SaveChangesAsync();
            return workGroup;
        }

        public async Task<WorkGroup> UpdateWorkGroup(WorkGroup workGroup)
        {
            _dbContext.WorkGroup.Update(workGroup);
            await _dbContext.SaveChangesAsync();
            return workGroup;
        }
    }
}
