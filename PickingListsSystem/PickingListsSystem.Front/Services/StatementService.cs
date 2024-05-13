using PickingListsSystem.Dto.Materials;
using PickingListsSystem.Dto.Statement;
using PickingListsSystem.Services.Contracts;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PickingListsSystem.Front.Services
{
    public class StatementService : IStatementService
    {
        protected readonly HttpClient _httpClient;

        public StatementService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddMaterialsToStatement(int statementId, List<int> materialIds)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Statement/addMaterials?statementId={statementId}", materialIds);
            response.EnsureSuccessStatusCode();
        }

        public async Task<int> AddStatement(CreateStatementDto statement)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Statement", statement);
            response.EnsureSuccessStatusCode();

            // Возвращаем Id добавленной ведомости
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task DeleteStatement(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StatementDto>> GetStatement()
        {
            throw new NotImplementedException();
        }

        public async Task<StatementDto> GetStatementID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateStatement(StatementDto statement)
        {
            throw new NotImplementedException();
        }
    }
}
