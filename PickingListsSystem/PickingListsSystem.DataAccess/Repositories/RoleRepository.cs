// методы для работы с баззой данных 
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(PlsDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Role>> GetRole()
        {
            var result = await _dbContext.Role.ToListAsync();
            return result;
        }

        public async Task<Role> GetRoleID(int id)
        {
           throw new NotImplementedException();
        }

        public async Task DeleteRole(int id)
        {
            var result = await _dbContext.Role.FindAsync(id);

            if (result != null)
            {
                _dbContext.Role.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Role> AddRole(Role role)
        {
            _dbContext.Role.Add(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRole(Role role)
        {
            _dbContext.Role.Update(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }
    }
}
