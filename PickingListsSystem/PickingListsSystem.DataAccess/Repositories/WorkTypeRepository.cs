using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Repositories
{
    public class WorkTypeRepository : BaseRepository, IWorkTypeRepository
    {
        public WorkTypeRepository(PlsDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<WorkType>> GetWorkType()
        {
            var result = await _dbContext.WorkType.ToListAsync();
            return result;
        }

        public async Task<WorkType> GetWorkTypeID(int id)
        {
            var result = await _dbContext.WorkType.FirstOrDefaultAsync(workType => workType.Id == id);
            return result;
        }

        public async Task DeleteWorkType(int id)
        {
            var result = await _dbContext.WorkType.FindAsync(id);

            if (result != null)
            {
                _dbContext.WorkType.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<WorkType> AddWorkType(WorkType workType)
        {
            _dbContext.WorkType.Add(workType);
            await _dbContext.SaveChangesAsync();
            return workType;
        }

        public async Task<WorkType> UpdateWorkType(WorkType workType)
        {
            _dbContext.WorkType.Update(workType);
            await _dbContext.SaveChangesAsync();
            return workType;
        }

    }
}
