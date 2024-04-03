using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Contracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetUser();
        Task<User> GetUserID(int id);
        Task DeleteUser(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
    }
}
