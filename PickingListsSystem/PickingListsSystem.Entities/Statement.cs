namespace PickingListsSystem.Entities
{
    public class Statement
    {
        public int Id { get; set; }

        public string? StatementStatus { get; set; }

        public DateTime? StatementDate { get; set; }
        public Project Project { get; set; } 

        public int ProjectId { get; set; }

        public List<Material> Materials { get; set; } = new(); 

        public Work Work { get; set; }

        public int WorkId { get; set; }
    }
}
