using AutoMapper;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.WorkType;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class WorkTypeService : IWorkTypeService
    {
        private readonly IMapper _mapper;
        private readonly IWorkTypeRepository _workTypeRepository;

        public WorkTypeService(IMapper mapper, IWorkTypeRepository workTypeRepository)
        {
            _mapper = mapper;
            _workTypeRepository = workTypeRepository;
        }

        public async Task<int> AddWorkType(CreateWorkTypeDto workType)
        {
            var entitytoAdd = _mapper.Map<CreateWorkTypeDto, WorkType>(workType);
            await _workTypeRepository.AddWorkType(entitytoAdd);
            return entitytoAdd.Id;
        }

        public async Task DeleteWorkType(int id)
        {
            await _workTypeRepository.DeleteWorkType(id);
        }

        public async Task<WorkTypeDto> GetWorkTypeID(int id)
        {
            //return _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialID(id));
            var workType = await _workTypeRepository.GetWorkTypeID(id);
            return _mapper.Map<WorkTypeDto>(workType);
        }

        public async Task<List<WorkTypeDto>> GetWorkType()
        {
            var workType = await _workTypeRepository.GetWorkType();
            return _mapper.Map<List<WorkTypeDto>>(workType);
        }

        public async Task<int> UpdateWorkType(WorkTypeDto workType)
        {
            var entitytoUpdate = _mapper.Map<CreateWorkTypeDto, WorkType>(workType);
            await _workTypeRepository.UpdateWorkType(entitytoUpdate);
            return entitytoUpdate.Id;
        }
    }
}
