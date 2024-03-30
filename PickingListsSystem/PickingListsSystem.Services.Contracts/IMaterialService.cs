using PickingListsSystem.Dto.Materials;

namespace PickingListsSystem.Services.Contracts
{
    public interface IMaterialService
    {
        Task<List<MaterialDto>> GetMaterials();
        Task<MaterialDto> GetMaterialID(int id);
        Task DeleteMaterial(int id);
        Task<int> AddMaterial(CreateMaterialDto material);
        Task<int> UpdateMaterial(MaterialDto material);
    }
}