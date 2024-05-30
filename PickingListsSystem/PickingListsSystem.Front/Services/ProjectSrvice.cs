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

        public async Task<int> AddProject(CreateProjectDto project)
        {
            var response = await _httpClient.PostAsJsonAsync("/Project", project);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task DeleteProject(int id)
        {
            var response = await _httpClient.DeleteAsync($"/Project?id={id}");
            response.EnsureSuccessStatusCode();
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

        public async Task<int> UpdateProject(ProjectDto project)
        {
            var response = await _httpClient.PutAsJsonAsync("/Project", project);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<int>();
        }

        public class AddProjectWorkRequest
        {
            public int ProjectId { get; set; }
            public List<int> WorkIds { get; set; }
        }

        public async Task AddWorkToProject(int projectId, List<int> workIds)
        {
            var request = new AddProjectWorkRequest
            {
                ProjectId = projectId,
                WorkIds = workIds
            };

            var response = await _httpClient.PostAsJsonAsync("/Project/addWork", request);
            response.EnsureSuccessStatusCode();
        }
    }
}
