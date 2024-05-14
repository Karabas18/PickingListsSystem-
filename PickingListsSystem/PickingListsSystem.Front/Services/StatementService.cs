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

        public class AddMaterialsRequest
        {
            public int StatementId { get; set; }
            public List<int> MaterialIds { get; set; }
        }

        public async Task AddMaterialsToStatement(int statementId, List<int> materialIds)
        {
            AddMaterialsRequest request = new AddMaterialsRequest() { StatementId = statementId, MaterialIds = materialIds };
            var response = await _httpClient.PostAsJsonAsync($"/Statement/addMaterials", request);
            response.EnsureSuccessStatusCode();
        }
        ////
        public class AddWorkRequest
        {
            public int StatementId { get; set; }
            public List<int> WorkIds { get; set; }
        }

        public async Task AddWorkToStatement(int statementId, List<int> workIds)
        {
            AddWorkRequest request = new AddWorkRequest() { StatementId = statementId, WorkIds = workIds };
            var response = await _httpClient.PostAsJsonAsync($"/Statement/addWork", request);
            response.EnsureSuccessStatusCode();
        }
        //
        public async Task<int> AddStatement(CreateStatementDto statement)
        {
            var response = await _httpClient.PostAsJsonAsync("/Statement", statement);
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
