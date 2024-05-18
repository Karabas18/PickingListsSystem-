using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Contracts
{
    public interface IMaterialRepository
    {
        Task<List<Material>> GetMaterials();
        Task<Material> GetMaterialID(int id);
        Task DeleteMaterial(int id);
        Task<Material> AddMaterial(Material material);
        Task<Material> UpdateMaterial(Material material);

    }
}
