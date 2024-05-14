using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Statement;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatementController : ControllerBase
    {
        private readonly IStatementService _statementService;

        private readonly ILogger<StatementController> _logger;

        public StatementController(IStatementService statementService, ILogger<StatementController> logger)
        {
            _statementService = statementService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<StatementDto>> GetAll()
        {
            return await _statementService.GetStatement();
        }

        [HttpGet("getbyid")]
        public async Task<StatementDto> GetID(int id)
        {
            return await _statementService.GetStatementID(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateStatementDto statement)
        {
            return await _statementService.AddStatement(statement);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] StatementDto statement)
        {
            return await _statementService.UpdateStatement(statement);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _statementService.DeleteStatement(id);
        }

        public class AddMaterialsRequest
        {
            public int StatementId { get; set; }
            public List<int> MaterialIds { get; set; }
        }

        [HttpPost("addMaterials")]
        public async Task<IActionResult> AddMaterialsToStatement([FromBody] AddMaterialsRequest request)
        {
            await _statementService.AddMaterialsToStatement(request.StatementId, request.MaterialIds);
            return Ok(); // Возвращаем 200 OK в случае успешного добавления
        }
        ////
        public class AddWorkRequest
        {
            public int StatementId { get; set; }
            public List<int> WorkIds { get; set; }
        }

        [HttpPost("addWork")]
        public async Task<IActionResult> AddWorkToStatement([FromBody] AddWorkRequest request)
        {
            await _statementService.AddWorkToStatement(request.StatementId, request.WorkIds);
            return Ok(); // Возвращаем 200 OK в случае успешного добавления
        }

    }
}