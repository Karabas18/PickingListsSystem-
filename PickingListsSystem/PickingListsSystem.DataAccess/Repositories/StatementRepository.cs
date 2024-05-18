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
                                          .Include(statement => statement.Project).ThenInclude(project => project.Work).ThenInclude(work => work.Materials)
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

        //public async Task AddMaterialsToStatement(int statementId, List<int> materialIds)
        //{
        //    var statement = await _dbContext.Statement.FindAsync(statementId);

        //    if (statement != null)
        //    {
        //        foreach (var materialId in materialIds)
        //        {
        //            var material = await _dbContext.Materials.FindAsync(materialId);
        //            if (material != null)
        //            {
        //                //statement.Materials.Add(material);
        //                statement.Project.Work.Materials.Add(material);
        //            }
        //        }
        //        await _dbContext.SaveChangesAsync();
        //    }
        //}
        //public async Task AddWorkToStatement(int statementId, List<int> workIds)
        //{
        //    var statement = await _dbContext.Statement.FindAsync(statementId);

        //    if (statement != null)
        //    {
        //        foreach (var workId in workIds)
        //        {
        //            var work = await _dbContext.Work.FindAsync(workId);
        //            if (work != null)
        //            {
        //                statement.Work.Add(work);
        //            }
        //        }
        //        await _dbContext.SaveChangesAsync();
        //    }
        //}

        public async Task AddToStatement(int statementId, int projectId, int? workId, List<int> materialIds)
        {
            // Загрузка ведомости с проектами, работами и материалами
            var statement = await _dbContext.Statement
                                            .Include(s => s.Project)
                                                .ThenInclude(p => p.Work)
                                                    .ThenInclude(w => w.Materials)
                                            .FirstOrDefaultAsync(s => s.Id == statementId);

            if (statement == null)
            {
                throw new ArgumentException("Statement not found.");
            }

            // Поиск проекта в базе данных
            var project = await _dbContext.Project.FindAsync(projectId);
            if (project == null)
            {
                throw new ArgumentException("Project not found.");
            }

            // Если проект уже добавлен в ведомость, пропустить его добавление
            if (!statement.Project.Any(p => p.Id == projectId))
            {
                statement.Project.Add(project);
                await _dbContext.SaveChangesAsync();
            }

            // Если workId не указан, мы закончили добавление проекта
            if (!workId.HasValue)
            {
                return;
            }

            // Поиск работы в базе данных
            var work = await _dbContext.Work.FindAsync(workId.Value);
            if (work == null)
            {
                throw new ArgumentException("Work not found.");
            }

            // Добавление работы в проект, если она еще не добавлена
            if (!project.Work.Any(w => w.Id == workId.Value))
            {
                project.Work.Add(work);
                await _dbContext.SaveChangesAsync();
            }

            // Если список materialIds пуст, мы закончили добавление работы
            if (materialIds == null || materialIds.Count == 0)
            {
                return;
            }

            // Загрузка всех материалов, которые нужно добавить
            var materials = await _dbContext.Materials
                                            .Where(m => materialIds.Contains(m.Id))
                                            .ToListAsync();

            if (materials.Count == 0)
            {
                throw new ArgumentException("No materials found with the provided IDs.");
            }

            // Добавление материалов в работу
            foreach (var material in materials)
            {
                if (!work.Materials.Any(m => m.Id == material.Id))
                {
                    work.Materials.Add(material);
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
