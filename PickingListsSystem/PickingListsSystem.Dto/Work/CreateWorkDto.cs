namespace PickingListsSystem.Dto.Work
{
    public class CreateWorkDto
    {
        public string? WorkCode { get; set; }

        public string? WorkDescription { get; set; }

        public string? WorkUnitMeasurement { get; set; }

        public int? WorkTypeId { get; set; }
    }
}
