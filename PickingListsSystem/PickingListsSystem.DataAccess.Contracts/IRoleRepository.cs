using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Contracts
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRole();
        Task<Role> GetRoleID(int id);
        Task DeleteRole(int id);
        Task<Role> AddRole(Role role);
        Task<Role> UpdateRole(Role role);
    }
}
