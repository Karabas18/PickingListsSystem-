using AutoMapper;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Materials;
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

        public Task<int> AddMaterial(CreateMaterialDto material)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMaterial(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MaterialDto> GetMaterialID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MaterialDto>> GetMaterials() 
        {
            var  materials = await _materialRepository.GetMaterials();
            return _mapper.Map<List<MaterialDto>>(materials);
        }

        public Task<int> UpdateMaterial(MaterialDto material)
        {
            throw new NotImplementedException();
        }
    }
}