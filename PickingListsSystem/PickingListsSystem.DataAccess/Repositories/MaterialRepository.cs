// методы для работы с баззой данных 
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Repositories
{
    internal class MaterialRepository : BaseRepository, IMaterialRepository
    {
        public MaterialRepository(PlsDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Material>> GetMaterial()
        {
            var result = await _dbContext.Materials.ToListAsync();
            return result;
        }

        // Добавлять, удалять, изменять, получать по ID 
    }
}
