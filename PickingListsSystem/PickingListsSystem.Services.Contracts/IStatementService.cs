using PickingListsSystem.Dto.Statement; 

namespace PickingListsSystem.Services.Contracts
{
    public interface IStatementService
    {
        Task<List<StatementDto>> GetStatement();
        Task<StatementDto> GetStatementID(int id);
        Task DeleteStatement(int id);
        Task<int> AddStatement(CreateStatementDto statement);
        Task<int> UpdateStatement(StatementDto statement);
        //
        //Task AddMaterialsToStatement(int statementId, List<int> materialIds);
        ////
        //Task AddWorkToStatement(int statementId, List<int> workIds);
        Task AddToStatement(int projectId, int? workId, List<int> materialIds);
    }
}