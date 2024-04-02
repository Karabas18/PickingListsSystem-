using PickingListsSystem.Dto.Role;

namespace PickingListsSystem.Services.Contracts
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetRole();
        Task<RoleDto> GetRoleID(int id);
        Task DeleteRole(int id);
        Task<int> AddRole(CreateRoleDto role);
        Task<int> UpdateRole(RoleDto role);
    }
}