using PickingListsSystem.Dto.Materials;
namespace PickingListsSystem.Dto.Work
{
    public class WorkDto : CreateWorkDto
    {
        public int Id { get; set; }

        public ICollection<MaterialDto> Materials { get; set; } = new List<MaterialDto>();
    }
}
