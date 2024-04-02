using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.WorkType;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkTypeController : ControllerBase
    {
        private readonly IWorkTypeService _workTypeService;

        private readonly ILogger<WorkTypeController> _logger;

        public WorkTypeController(IWorkTypeService workTypeService, ILogger<WorkTypeController> logger)
        {
            _workTypeService = workTypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<WorkTypeDto>> GetAll()
        {
            return await _workTypeService.GetWorkType();
        }

        [HttpGet("getbyid")]
        public async Task<WorkTypeDto> GetID(int id)
        {
            return await _workTypeService.GetWorkTypeID(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateWorkTypeDto workType)
        {
            return await _workTypeService.AddWorkType(workType);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] WorkTypeDto workType)
        {
            return await _workTypeService.UpdateWorkType(workType);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _workTypeService.DeleteWorkType(id);
        }

    }
}