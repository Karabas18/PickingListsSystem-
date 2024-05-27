namespace PickingListsSystem.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public string? ProjectObject { get; set; }

        public string? ProjectPlan { get; set; }

        public string? ProjectStatus { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public ICollection<WorkGroup> WorkGroup { get; set; } = new List<WorkGroup>();

        public ICollection<Work> Work { get; set; } = new List<Work>();

        public ICollection<Statement> Statement { get; set; } = new List<Statement>();
    }
}
