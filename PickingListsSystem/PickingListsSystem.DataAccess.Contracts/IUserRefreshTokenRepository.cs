using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Contracts
{
    public interface IUserRefreshTokenRepository
    {
        Task<UserRefreshToken> CreateAsync(UserRefreshToken token);
        Task<UserRefreshToken> UpdateAsync(UserRefreshToken token);
        Task<List<UserRefreshToken>> GetExpiredByUserIdAsync(string id);
        Task<UserRefreshToken?> GetByUserIdAndTokenAsync(string userId, string token);
        Task DeleteAsync(List<string> tokenIds);
    }
}