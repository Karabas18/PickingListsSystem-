using AutoMapper;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Work;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class WorkService : IWorkService
    {
        private readonly IMapper _mapper;
        private readonly IWorkRepository _workRepository;
        //
        private readonly IMaterialRepository _materialRepository;

        public WorkService(IMapper mapper, IWorkRepository workRepository, IMaterialRepository materialRepository)
        {
            _mapper = mapper;
            _workRepository = workRepository;
            _materialRepository = materialRepository;
        }

        public async Task<int> AddWork(CreateWorkDto work)
        {
            var entitytoAdd = _mapper.Map<CreateWorkDto, Work>(work);
            await _workRepository.AddWork(entitytoAdd);
            return entitytoAdd.Id;
        }

        public async Task DeleteWork(int id)
        {
            await _workRepository.DeleteWork(id);
        }

        public async Task<WorkDto> GetWorkID(int id)
        {
            //return _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialID(id));
            var work = await _workRepository.GetWorkID(id);
            return _mapper.Map<WorkDto>(work);
        }

        public async Task<List<WorkDto>> GetWork()
        {
            var work = await _workRepository.GetWork();
            return _mapper.Map<List<WorkDto>>(work);
        }

        public async Task<int> UpdateWork(WorkDto work)
        {
            var entitytoUpdate = _mapper.Map<CreateWorkDto, Work>(work);
            await _workRepository.UpdateWork(entitytoUpdate);
            return entitytoUpdate.Id;
        }

        public async Task AddMaterialsToWork(int workId, List<int> materialIds)
        {
            var work = await _workRepository.GetWorkID(workId);

            if (work != null)//stop
            {
                foreach (var materialId in materialIds)
                {
                    var material = await _materialRepository.GetMaterialID(materialId);
                    if (material != null)
                    {
                        work.Materials.Add(material);
                    }
                }
                await _workRepository.UpdateWork(work);
            }
        }
    }
}
