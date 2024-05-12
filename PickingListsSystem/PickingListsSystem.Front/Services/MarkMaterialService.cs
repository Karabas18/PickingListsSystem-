using PickingListsSystem.Dto.Materials;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class MarkMaterialService
    {
        private static List<MaterialDto> MarkedMaterial;

        public MarkMaterialService()
        {
            MarkedMaterial = new List<MaterialDto>();
        }

        public async static Task AddSelectedMaterial(MaterialDto material)
        {
            /*if (!MarkedMaterial.Contains(material))
            {
                MarkedMaterial.Add(material);
            }*/

            if (!MarkedMaterial.Any(m => m.Id == material.Id))
            {
                MarkedMaterial.Add(material);
            }
        }
        public static IEnumerable<MaterialDto> GetSelectedMaterial()
        {
            return MarkedMaterial;
        }
    }
}