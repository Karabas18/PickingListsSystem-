
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Repositories
{
    public class UserRefreshTokenRepository : BaseRepository, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(PlsDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserRefreshToken> CreateAsync(UserRefreshToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            _dbContext.Add(token);
            await _dbContext.SaveChangesAsync();
            return token;
        }

        public async Task<UserRefreshToken> UpdateAsync(UserRefreshToken token)
        {
            _dbContext.Update(token);
            await _dbContext.SaveChangesAsync();

            return token;
        }


        public async Task<List<UserRefreshToken>> GetExpiredByUserIdAsync(string id)
        {
            var results = await _dbContext.UserRefreshTokens
                                        .AsNoTracking()
                                        .Where(x => x.UserId == id.ToLowerInvariant() && x.ExpiresUtc < DateTime.Now)
                                        .ToListAsync();
            return results;
        }

        public async Task<UserRefreshToken?> GetByUserIdAndTokenAsync(string userId, string refreshToken)
        {
            var result = await _dbContext.UserRefreshTokens
                            .SingleOrDefaultAsync(x => x.UserId == userId && x.RefreshToken == refreshToken);

            return result;
        }

        public async Task DeleteAsync(List<string> ids)
        {
            var entitiesToDelete = await _dbContext.UserRefreshTokens
                            .Where(d => ids.Contains(d.Id)).ToListAsync();
            if (entitiesToDelete != null)
            {
                _dbContext.RemoveRange(entitiesToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
