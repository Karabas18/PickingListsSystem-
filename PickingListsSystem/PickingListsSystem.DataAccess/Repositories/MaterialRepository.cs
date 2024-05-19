// методы для работы с баззой данных 
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Repositories
{
    public class MaterialRepository : BaseRepository, IMaterialRepository
    {
        public MaterialRepository(PlsDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Material>> GetMaterials()
        {
            var result = await _dbContext.Materials.ToListAsync();
            return result;
        }

        public async Task<List<Material>> GetMaterials(List<int> materialIds)
        {
            var result = await _dbContext.Materials.Where(x=>materialIds.Contains(x.Id)).ToListAsync();
            return result;
        }

        public async Task<Material> GetMaterialID(int id)
        {
            var result = await _dbContext.Materials.FirstOrDefaultAsync(material => material.Id == id);
            return result;
        }


        

        public async Task DeleteMaterial(int id)
        {
            var result = await _dbContext.Materials.FindAsync(id);

            if (result != null)
            {
                _dbContext.Materials.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Material> AddMaterial(Material material)
        {
            _dbContext.Materials.Add(material);
            await _dbContext.SaveChangesAsync();
            return material;
        }

        public async Task<Material> UpdateMaterial(Material material)
        {
            _dbContext.Materials.Update(material);
            await _dbContext.SaveChangesAsync();
            return material;
        }
    }
}
