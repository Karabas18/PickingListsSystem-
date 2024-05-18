using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Project;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectService projectService, ILogger<ProjectController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<ProjectDto>> GetAll()
        {
            return await _projectService.GetProject();
        }

        [HttpGet("getbyid")]
        public async Task<ProjectDto> GetID(int id)
        {
            return await _projectService.GetProjectID(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateProjectDto project)
        {
            return await _projectService.AddProject(project);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] ProjectDto project)
        {
            return await _projectService.UpdateProject(project);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _projectService.DeleteProject(id);
        }

        public class AddProjectRequest
        {
            public int ProjectId { get; set; }
            public List<int> WorkIds { get; set; } 
        }

        [HttpPost("addWork")]
        public async Task<IActionResult> AddWorkToProject([FromBody] AddProjectRequest request)
        {
            await _projectService.AddWorkToProject(request.ProjectId, request.WorkIds);
            return Ok(); // Возвращаем 200 OK в случае успешного добавления
        }

    }
}