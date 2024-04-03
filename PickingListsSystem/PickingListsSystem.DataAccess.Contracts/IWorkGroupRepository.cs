using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Contracts
{
    public interface IWorkGroupRepository
    {
        Task<List<WorkGroup>> GetWorkGroup();
        Task<WorkGroup> GetWorkGroupID(int id);
        Task DeleteWorkGroup(int id);
        Task<WorkGroup> AddWorkGroup(WorkGroup workGroup);
        Task<WorkGroup> UpdateWorkGroup(WorkGroup workGroup);
    }
}
