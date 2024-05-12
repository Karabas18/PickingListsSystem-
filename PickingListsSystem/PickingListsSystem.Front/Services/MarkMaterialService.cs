using PickingListsSystem.Dto.Materials;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class MarkMaterialService
    {
        private static List<MaterialDto> MarkedMaterial;
        private static Dictionary<int, int> ClickCounts = new Dictionary<int, int>();
        public MarkMaterialService()
        {
            MarkedMaterial = new List<MaterialDto>();
        }

        public async static Task AddSelectedMaterial(MaterialDto material)
        {
            if (MarkedMaterial.Any(m => m.Id == material.Id))
            {
                ClickCounts[material.Id]++;
            }
            else
            {
                MarkedMaterial.Add(material); 
                ClickCounts[material.Id] = 1; 
            }
        }
        //
        public async static Task DeleteSelectedMaterial(int itemId)
        {
            if (ClickCounts.ContainsKey(itemId))
            {
                ClickCounts[itemId]--;
                if (ClickCounts[itemId] <= 0)
                {
                    MarkedMaterial.RemoveAll(item => item.Id == itemId);
                    ClickCounts.Remove(itemId);
                }
            }
        }
        //
        public static (IEnumerable<MaterialDto>, Dictionary<int, int>) GetSelectedMaterial()
        {
            return (MarkedMaterial, ClickCounts);
        }

    }
}