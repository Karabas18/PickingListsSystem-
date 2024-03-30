using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Materials;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        private readonly ILogger<MaterialController> _logger;

        public MaterialController(IMaterialService materialService, ILogger<MaterialController> logger)
        {
            _materialService = materialService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<MaterialDto>> GetAll()
        {
            return await _materialService.GetMaterials();
        }

        [HttpPost]
        public async Task<int> Create([FromBody]CreateMaterialDto material)
        {
            return await _materialService.AddMaterial(material);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] MaterialDto material)
        {
            return await _materialService.UpdateMaterial(material);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
           await _materialService.DeleteMaterial(id);
        }

    }
}