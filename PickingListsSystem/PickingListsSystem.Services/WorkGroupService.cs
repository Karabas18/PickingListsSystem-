using AutoMapper;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.WorkGroup;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class WorkGroupService : IWorkGroupService
    {
        private readonly IMapper _mapper;
        private readonly IWorkGroupRepository _workGroupRepository;

        public WorkGroupService(IMapper mapper, IWorkGroupRepository workGroupRepository)
        {
            _mapper = mapper;
            _workGroupRepository = workGroupRepository;
        }

        public async Task<int> AddWorkGroup(CreateWorkGroupDto workGroup)
        {
            var entitytoAdd = _mapper.Map<CreateWorkGroupDto, WorkGroup>(workGroup);
            await _workGroupRepository.AddWorkGroup(entitytoAdd);
            return entitytoAdd.Id;
        }

        public async Task DeleteWorkGroup(int id)
        {
            await _workGroupRepository.DeleteWorkGroup(id);
        }

        public async Task<WorkGroupDto> GetWorkGroupID(int id)
        {
            //return _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialID(id));
            var workGroup = await _workGroupRepository.GetWorkGroupID(id);
            return _mapper.Map<WorkGroupDto>(workGroup);
        }

        public async Task<List<WorkGroupDto>> GetWorkGroup()
        {
            var workGroup = await _workGroupRepository.GetWorkGroup();
            return _mapper.Map<List<WorkGroupDto>>(workGroup);
        }

        public async Task<int> UpdateWorkGroup(WorkGroupDto workGroup)
        {
            var entitytoUpdate = _mapper.Map<CreateWorkGroupDto, WorkGroup>(workGroup);
            await _workGroupRepository.UpdateWorkGroup(entitytoUpdate);
            return entitytoUpdate.Id;
        }
    }
}
