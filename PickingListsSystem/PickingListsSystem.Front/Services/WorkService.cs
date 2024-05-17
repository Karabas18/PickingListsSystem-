using PickingListsSystem.Dto.Work;
using PickingListsSystem.Services.Contracts;
using System.Net.Http.Json;

namespace PickingListsSystem.Front.Services
{
    public class WorkService : IWorkService
    {
        protected readonly HttpClient _httpClient;

        public WorkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<int> AddWork(CreateWorkDto work)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWork(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WorkDto>> GetWork()
        {
            var response = await _httpClient.GetFromJsonAsync<List<WorkDto>>($"Work");
            return response ?? throw new HttpRequestException("Couldn't get vessels");
        }

        public async Task<WorkDto> GetWorkID(int id)
        {
            var response = await _httpClient.GetAsync($"Work/getbyid?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var workDto = await response.Content.ReadFromJsonAsync<WorkDto>();
                return workDto ?? throw new HttpRequestException($"Couldn't get material with ID {id}");
            }
            else
            {
                throw new HttpRequestException($"Failed to get material with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public Task<int> UpdateWork(WorkDto work)
        {
            throw new NotImplementedException();
        }

        public Task AddMaterialsToWork(int statementId, List<int> materialIds)
        {
            throw new NotImplementedException();
        }
    }
}
