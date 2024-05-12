using PickingListsSystem.Dto.Role;

namespace PickingListsSystem.Services.Contracts
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetRole();
        Task<RoleDto> GetRoleID(int id);
        Task DeleteRole(int id);
        Task<string> AddRole(CreateRoleDto role);
        Task<string> UpdateRole(RoleDto role);
    }
}