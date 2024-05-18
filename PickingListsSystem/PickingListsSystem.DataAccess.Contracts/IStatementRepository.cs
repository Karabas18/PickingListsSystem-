using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Contracts
{
    public interface IStatementRepository
    {
        Task<List<Statement>> GetStatement();
        Task<Statement> GetStatementID(int id);
        Task DeleteStatement(int id);
        Task<Statement> AddStatement(Statement statement);
        Task<Statement> UpdateStatement(Statement statement);
        //
        //Task AddMaterialsToStatement(int statementId, List<int> materialIds);
        //
        //Task AddWorkToStatement(int statementId, List<int> workIds);
        //
        //
        Task AddToStatement(int statementId, int projectId, int? workId, List<int> materialIds);
    }
}
