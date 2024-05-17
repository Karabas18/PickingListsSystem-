using PickingListsSystem.Dto.Project;
using PickingListsSystem.Services.Contracts;
using System.Net.Http.Json;

namespace PickingListsSystem.Front.Services
{
    public class ProjectService : IProjectService
    {
        protected readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<int> AddProject(CreateProjectDto project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProjectDto>> GetProject()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ProjectDto>>($"Project");
            return response ?? throw new HttpRequestException("Couldn't get vessels");
        }

        public async Task<ProjectDto> GetProjectID(int id)
        {
            var response = await _httpClient.GetAsync($"Project/getbyid?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var projectDto = await response.Content.ReadFromJsonAsync<ProjectDto>();
                return projectDto ?? throw new HttpRequestException($"Couldn't get project with ID {id}");
            }
            else
            {
                throw new HttpRequestException($"Failed to get project with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public Task<int> UpdateProject(ProjectDto project)
        {
            throw new NotImplementedException();
        }
    }
}
