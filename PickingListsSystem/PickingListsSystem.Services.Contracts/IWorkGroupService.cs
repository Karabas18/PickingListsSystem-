using PickingListsSystem.Dto.WorkGroup;

namespace PickingListsSystem.Services.Contracts
{
    public interface IWorkGroupService
    {
        Task<List<WorkGroupDto>> GetWorkGroup();
        Task<WorkGroupDto> GetWorkGroupID(int id);
        Task DeleteWorkGroup(int id);
        Task<int> AddWorkGroup(CreateWorkGroupDto workGroup);
        Task<int> UpdateWorkGroup(WorkGroupDto workGroup);
    }
}
