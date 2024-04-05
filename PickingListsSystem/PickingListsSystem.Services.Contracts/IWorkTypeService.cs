using PickingListsSystem.Dto.WorkType;

namespace PickingListsSystem.Services.Contracts
{
    public interface IWorkTypeService
    {
        Task<List<WorkTypeDto>> GetWorkType();
        Task<WorkTypeDto> GetWorkTypeID(int id);
        Task DeleteWorkType(int id);
        Task<int> AddWorkType(CreateWorkTypeDto workType);
        Task<int> UpdateWorkType(WorkTypeDto workType);
    }
}
