using PickingListsSystem.Dto.User;

namespace PickingListsSystem.Services.Contracts
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUser();
        Task<UserDto> GetUserID(int id);
        Task DeleteUser(int id);
        Task<string> AddUser(CreateUserDto user);
        Task<string> UpdateUser(UserDto user);
    }
}