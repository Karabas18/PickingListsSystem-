using PickingListsSystem.Dto.WorkType;
using PickingListsSystem.Services.Contracts;
using System.Net.Http.Json;

namespace PickingListsSystem.Front.Services
{
    public class WorkTypeService : IWorkTypeService
    {
        protected readonly HttpClient _httpClient;

        public WorkTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<int> AddWorkType(CreateWorkTypeDto workType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWorkType(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WorkTypeDto>> GetWorkType()
        {
            var response = await _httpClient.GetFromJsonAsync<List<WorkTypeDto>>("WorkType");
            return response ?? throw new HttpRequestException("Couldn't get work types");
        }

        public Task<WorkTypeDto> GetWorkTypeID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateWorkType(WorkTypeDto workType)
        {
            throw new NotImplementedException();
        }
    }
}
