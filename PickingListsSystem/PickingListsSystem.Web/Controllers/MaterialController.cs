using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialRepository _materialRepository;

        private readonly ILogger<MaterialController> _logger;

        public MaterialController(IMaterialRepository materialRepository, ILogger<MaterialController> logger)
        {
            _materialRepository = materialRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Material>> GetAll()
        {
            return await _materialRepository.GetMaterials();
        }

        [HttpPost]
        public async Task<Material> Create([FromBody]Material material)
        {
            return await _materialRepository.AddMaterial(material);
        }

        [HttpPut]
        public async Task<Material> Update([FromBody] Material material)
        {
            return await _materialRepository.UpdateMaterial(material);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
           await _materialRepository.DeleteMaterial(id);
        }

    }
}