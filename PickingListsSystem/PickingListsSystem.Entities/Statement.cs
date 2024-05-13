namespace PickingListsSystem.Entities
{
    public class Statement
    {
        public int Id { get; set; }

        public string? StatementStatus { get; set; }

        public DateTime? StatementDate { get; set; }
        public ICollection<Project> Project { get; set; }

        //public ICollection<Material> Materials { get; set; }
        public ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
