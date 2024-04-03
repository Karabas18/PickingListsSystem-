using PickingListsSystem.Entities;
namespace PickingListsSystem.Dto.WorkGroup  
{
    public class CreateWorkGroupDto
    {
        public string? WorkGroupStructure { get; set; }

        public Entities.User? WorkGroupDirector { get; set; }
    }
}
