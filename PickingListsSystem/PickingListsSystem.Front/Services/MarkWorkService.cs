using PickingListsSystem.Dto.Work;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class MarkWorkService
    {
        private static List<WorkDto> MarkedWork;
        private static Dictionary<int, int> ClickCounts = new Dictionary<int, int>();
        public MarkWorkService()
        {
            MarkedWork = new List<WorkDto>();
        }

        public async static Task AddSelectedWork(WorkDto work)
        {
            if (MarkedWork.Any(m => m.Id == work.Id))
            {
                ClickCounts[work.Id]++;
            }
            else
            {
                MarkedWork.Add(work); 
                ClickCounts[work.Id] = 1; 
            }
        }
        //
        public async static Task DeleteSelectedWork(int itemId)
        {
            if (ClickCounts.ContainsKey(itemId))
            {
                ClickCounts[itemId]--;
                if (ClickCounts[itemId] <= 0)
                {
                    MarkedWork.RemoveAll(item => item.Id == itemId);
                    ClickCounts.Remove(itemId);
                }
            }
        }
        //
        public static (IEnumerable<WorkDto>, Dictionary<int, int>) GetSelectedWork()
        {
            return (MarkedWork, ClickCounts);
        }

    }
}