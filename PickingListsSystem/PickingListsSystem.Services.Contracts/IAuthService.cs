using PickingListsSystem.Dto.User;

namespace PickingListsSystem.Services.Contracts
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegisterResponse> Register(RegisterRequest request);
        Task<UserDto?> GetProfile(string userId);
        Task<LoginResponse> Refresh(RefreshTokenRequest dto);

        Task<bool> ChangeUserRoleToAdmin(string userId);
    }
}