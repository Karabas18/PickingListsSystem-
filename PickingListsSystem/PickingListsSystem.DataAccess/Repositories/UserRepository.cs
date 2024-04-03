// методы для работы с баззой данных 
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(PlsDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<User>> GetUser()
        {
            var result = await _dbContext.User.ToListAsync();
            return result;
        }

        public async Task<User> GetUserID(int id)
        {
            var result = await _dbContext.User.FirstOrDefaultAsync(user => user.Id == id);
            return result;
        }

        public async Task DeleteUser(int id)
        {
            var result = await _dbContext.User.FindAsync(id);

            if (result != null)
            {
                _dbContext.User.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<User> AddUser(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _dbContext.User.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
