using PickingListsSystem.Dto.Materials;
using PickingListsSystem.Services.Contracts;
using System.Net.Http.Json;
namespace PickingListsSystem.Services
{   
    public class SelectedItemsService
    {
        public int ProjectId { get; private set; }
        public int? WorkId { get; private set; }
        public List<int> MaterialIds { get; private set; } = new List<int>();

        public void SetProjectId(int projectId)
        {
            ProjectId = projectId;
        }

        public void SetWorkId(int? workId)
        {
            WorkId = workId;
        }

        public void SetMaterialIds(List<int> materialIds)
        {
            MaterialIds = materialIds;
        }

    }
}