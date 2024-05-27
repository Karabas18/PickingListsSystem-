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

        public class AddToStatementRequest
        {
            public int ProjectId { get; set; }
            public int? WorkId { get; set; }
            public List<int> MaterialIds { get; set; }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToStatement([FromBody] AddToStatementRequest request)
        {
            try
            {
                await _statementService.AddToStatement(request.ProjectId, request.WorkId, request.MaterialIds);
                return Ok("Statement updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding to statement: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

    }
}