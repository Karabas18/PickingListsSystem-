using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Repositories
{
    public class StatementRepository : BaseRepository, IStatementRepository
    {
        public StatementRepository(PlsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Statement>> GetStatement()
        {
            var result = await _dbContext.Statement
                                          .Include(statement => statement.Project)
                                          .Include(project => project.Work)
                                          .Include(work => work.Materials)
                                          .ToListAsync();
            return result;
        }

        public async Task<Statement> GetStatementID(int id)
        {
            var result = await _dbContext.Statement
                                          .Include(statement => statement.Project).ThenInclude(project => project.Work).ThenInclude(work => work.Materials)
                                          .FirstOrDefaultAsync(statement => statement.Id == id);
            return result;
        }

        public async Task DeleteStatement(int id)
        {
            var result = await _dbContext.Statement.FindAsync(id);

            if (result != null)
            {
                _dbContext.Statement.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task<Statement> AddStatement(Statement statement)
        {
            _dbContext.Statement.Add(statement);
            await _dbContext.SaveChangesAsync();
            return statement;
        }

        public async Task<Statement> UpdateStatement(Statement statement)
        {
            _dbContext.Statement.Update(statement);
            await _dbContext.SaveChangesAsync();
            return statement;
        }

        public Task AddToStatement(int statementId, int projectId, int? workId, List<int> materialIds)
        {
            throw new NotImplementedException();
        }
    }
}
