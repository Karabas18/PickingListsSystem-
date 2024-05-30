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

        public async Task<int> AddWork(CreateWorkDto work)
        {
            var response = await _httpClient.PostAsJsonAsync("/Work", work);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task DeleteWork(int id)
        {
            var response = await _httpClient.DeleteAsync($"/Work?id={id}");
            response.EnsureSuccessStatusCode();
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

        public async Task<int> UpdateWork(WorkDto work)
        {
            var response = await _httpClient.PutAsJsonAsync("/Work", work);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<int>();
        }

        public class AddWorkRequest1
        {
            public int WorkId { get; set; }
            public List<int> MaterialIds { get; set; }
        }

        public async Task AddMaterialsToWork(int workId, List<int> materialIds)
        {
            AddWorkRequest1 request = new AddWorkRequest1() { WorkId = workId, MaterialIds = materialIds };
            var response = await _httpClient.PostAsJsonAsync($"/Work/addWorkMaterials", request);
            response.EnsureSuccessStatusCode();
        }
    }
}
