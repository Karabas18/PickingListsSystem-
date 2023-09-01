using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Contracts
{
    public interface IMaterialRepository
    {
        Task<List<Material>> GetMaterial();
    }
}
