using PickingListsSystem.Dto.Work;
namespace PickingListsSystem.Dto.Project
{
    public class ProjectDto : CreateProjectDto
    {
        public int Id { get; set; }

        public ICollection<WorkDto> Work { get; set; } = new List<WorkDto>();//try3
    }
}
