using AutoMapper;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Materials;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMapper mapper, IMaterialRepository materialRepository)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
        }

        public async Task<int> AddMaterial(CreateMaterialDto material)
        {
            var entitytoAdd = _mapper.Map<CreateMaterialDto, Material>(material);
            await _materialRepository.AddMaterial(entitytoAdd);
            return entitytoAdd.Id;
        }

        public async Task DeleteMaterial(int id)
        {
           await _materialRepository.DeleteMaterial(id);
        }

        public async Task<MaterialDto> GetMaterialID(int id)
        {
            //return _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialID(id));
            var material = await _materialRepository.GetMaterialID(id);
            return _mapper.Map<MaterialDto>(material);
        }

        public async Task<List<MaterialDto>> GetMaterials() 
        {
            var materials = await _materialRepository.GetMaterials();
            return _mapper.Map<List<MaterialDto>>(materials);
        }

        public async Task<int> UpdateMaterial(MaterialDto material)
        {
            var entitytoUpdate = _mapper.Map<CreateMaterialDto, Material>(material);
            await _materialRepository.UpdateMaterial(entitytoUpdate);
            return entitytoUpdate.Id;
        }
    }
}