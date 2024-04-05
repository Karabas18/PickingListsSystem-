namespace PickingListsSystem.Entities
{
    public class Work
    {
        public int Id { get; set; }

        public string? WorkCode { get; set; }

        public string? WorkDescription { get; set; }

        public string? WorkUnitMeasurement { get; set; }

        public int? WorkTypeId { get; set; }
        public WorkType WorkType { get; set; }

        public ICollection<Material> Material { get; set; }

    }
}
