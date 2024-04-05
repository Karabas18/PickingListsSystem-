using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Contracts
{
    public interface IWorkTypeRepository
    {
        Task<List<WorkType>> GetWorkType();
        Task<WorkType> GetWorkTypeID(int id);
        Task DeleteWorkType(int id);
        Task<WorkType> AddWorkType(WorkType workType);
        Task<WorkType> UpdateWorkType(WorkType workType);
    }
}
