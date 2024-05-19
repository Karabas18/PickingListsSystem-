using PickingListsSystem.Dto.Materials;
using PickingListsSystem.Dto.Project;
using PickingListsSystem.Dto.Work;

namespace PickingListsSystem.Dto.Statement

{
    public class StatementDto : CreateStatementDto
    {
        public int Id { get; set; }
        //
        public ICollection<MaterialDto> Materials { get; set; } = new List<MaterialDto>();

        public ProjectDto Project { get; set; }

        public WorkDto Work { get; set; }


    }
}
