// методы для работы с баззой данных 
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
            var result = await _dbContext.Statement.ToListAsync();
            return result;
        }

        public async Task<Statement> GetStatementID(int id)
        {
            var result = await _dbContext.Statement.FirstOrDefaultAsync(statement => statement.Id == id);
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

        public async Task AddMaterialsToStatement(int statementId, List<int> materialIds)
        {
            var statement = await _dbContext.Statement.FindAsync(statementId);

            if (statement != null)
            {
                foreach (var materialId in materialIds)
                {
                    var material = await _dbContext.Materials.FindAsync(materialId);
                    if (material != null)
                    {
                        statement.Materials.Add(material);
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task AddWorkToStatement(int statementId, List<int> workIds)
        {
            var statement = await _dbContext.Statement.FindAsync(statementId);

            if (statement != null)
            {
                foreach (var workId in workIds)
                {
                    var work = await _dbContext.Work.FindAsync(workId);
                    if (work != null)
                    {
                        statement.Work.Add(work);
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
