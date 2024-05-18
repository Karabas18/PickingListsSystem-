using PickingListsSystem.Dto.Project;
namespace PickingListsSystem.Dto.Statement

{
    public class StatementDto : CreateStatementDto
    {
        public int Id { get; set; }
        //
        //public ICollection<MaterialDto> Materials { get; set; } = new List<MaterialDto>();

        public ICollection<ProjectDto> Project { get; set; } = new List<ProjectDto>();
    }
}
