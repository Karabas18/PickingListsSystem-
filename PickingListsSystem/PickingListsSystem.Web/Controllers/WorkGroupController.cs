using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.WorkGroup;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkGroupController : ControllerBase
    {
        private readonly IWorkGroupService _workGroupService;

        private readonly ILogger<WorkGroupController> _logger;

        public WorkGroupController(IWorkGroupService workGroupService, ILogger<WorkGroupController> logger)
        {
            _workGroupService = workGroupService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<WorkGroupDto>> GetAll()
        {
            return await _workGroupService.GetWorkGroup();
        }

        [HttpGet("getbyid")]
        public async Task<WorkGroupDto> GetID(int id)
        {
            return await _workGroupService.GetWorkGroupID(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateWorkGroupDto workGroup)
        {
            return await _workGroupService.AddWorkGroup(workGroup);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] WorkGroupDto workGroup)
        {
            return await _workGroupService.UpdateWorkGroup(workGroup);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _workGroupService.DeleteWorkGroup(id);
        }

    }
}