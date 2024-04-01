using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Contracts
{
    public interface IWorkRepository
    {
        Task<List<Work>> GetWork();
        Task<Work> GetWorkID(int id);
        Task DeleteWork(int id);
        Task<Work> AddWork(Work work);
        Task<Work> UpdateWork(Work work);
    }
}
