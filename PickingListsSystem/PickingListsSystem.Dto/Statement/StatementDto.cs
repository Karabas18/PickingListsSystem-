using PickingListsSystem.Dto.Materials;
namespace PickingListsSystem.Dto.Statement

{
    public class StatementDto : CreateStatementDto
    {
        public int Id { get; set; }
        //
        public ICollection<MaterialDto> Materials { get; set; } = new List<MaterialDto>();
    }
}
