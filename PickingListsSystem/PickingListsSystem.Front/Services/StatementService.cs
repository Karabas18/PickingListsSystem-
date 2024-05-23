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
        public async Task<int> AddStatement(CreateStatementDto statement)
        {
            var response = await _httpClient.PostAsJsonAsync("/Statement", statement);
            response.EnsureSuccessStatusCode();

            // Возвращаем Id добавленной ведомости
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public class AddToStatementRequest
        {
            public int ProjectId { get; set; }
            public int? WorkId { get; set; }
            public List<int> MaterialIds { get; set; }
        }

        public async Task AddToStatement(int projectId, int? workId, List<int> materialIds)
        {
                AddToStatementRequest request = new AddToStatementRequest() { ProjectId = projectId, WorkId = workId, MaterialIds = materialIds };
            var response = await _httpClient.PostAsJsonAsync("/Statement/add", request);
            response.EnsureSuccessStatusCode();
        }

        //

        public async Task DeleteStatement(int id)
        {
            var response = await _httpClient.DeleteAsync($"/Statement?id={id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<StatementDto>> GetStatement()
        {
            var response = await _httpClient.GetFromJsonAsync<List<StatementDto>>($"Statement");
            return response ?? throw new HttpRequestException("Couldn't get vessels");
        }

        public async Task<StatementDto> GetStatementID(int id)
        {
            var response = await _httpClient.GetAsync($"Statement/getbyid?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var statementDto = await response.Content.ReadFromJsonAsync<StatementDto>();
                return statementDto ?? throw new HttpRequestException($"Couldn't get statement with ID {id}");
            }
            else
            {
                throw new HttpRequestException($"Failed to get statement with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public async Task<int> UpdateStatement(StatementDto statement)
        {
            var response = await _httpClient.PutAsJsonAsync("/Statement", statement);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}
