using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Repositories
{
    public class WorkRepository : BaseRepository, IWorkRepository
    {
        public WorkRepository(PlsDbContext dbContext) : base(dbContext)
        {

        }
        //public async Task<List<Work>> GetWork()
        //{
        //    var result = await _dbContext.Work.ToListAsync();
        //    return result;
        //}

        public async Task<List<Work>> GetWork()
        {
            var result = await _dbContext.Work
                                          .Include(work => work.Materials)
                                          .ToListAsync();
            return result;
        }

        //public async Task<Work> GetWorkID(int id)
        //{
        //    var result = await _dbContext.Work.FirstOrDefaultAsync(work => work.Id == id);
        //    return result;
        //}

        public async Task<Work> GetWorkID(int id)
        {
            var result = await _dbContext.Work
                                          .Include(work => work.Materials)
                                          .FirstOrDefaultAsync(work => work.Id == id);
            return result;
        }

        public async Task DeleteWork(int id)
        {
            var result = await _dbContext.Work.FindAsync(id);

            if (result != null)
            {
                _dbContext.Work.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Work> AddWork(Work work)
        {
            _dbContext.Work.Add(work);
            await _dbContext.SaveChangesAsync();
            return work;
        }

        public async Task<Work> UpdateWork(Work work)
        {
            _dbContext.Work.Update(work);
            await _dbContext.SaveChangesAsync();
            return work;
        }

        public async Task AddMaterialsToWork(int workId, List<int> materialIds)
        {
            var work = await _dbContext.Work.FindAsync(workId);

            if (work != null)
            {
                foreach (var materialId in materialIds)
                {
                    var material = await _dbContext.Materials.FindAsync(materialId);
                    if (material != null)
                    {
                        work.Materials.Add(material);
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
