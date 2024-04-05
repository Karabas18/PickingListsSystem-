using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Work;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkController : ControllerBase
    {
        private readonly IWorkService _workService;

        private readonly ILogger<WorkController> _logger;

        public WorkController(IWorkService workService, ILogger<WorkController> logger)
        {
            _workService = workService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<WorkDto>> GetAll()
        {
            return await _workService.GetWork();
        }

        [HttpGet("getbyid")]
        public async Task<WorkDto> GetID(int id)
        {
            return await _workService.GetWorkID(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateWorkDto work)
        {
            return await _workService.AddWork(work);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] WorkDto work)
        {
            return await _workService.UpdateWork(work);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _workService.DeleteWork(id);
        }

    }
}