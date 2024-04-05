namespace PickingListsSystem.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public string? ProjectObject { get; set; }

        public string? ProjectPlan { get; set; }

        public string? ProjectStatus { get; set; }

        public WorkType WorkType { get; set; }

        public Customer Customer { get; set; }

        public ICollection<WorkGroup> WorkGroup { get; set; }

        public ICollection<Statement> Statement { get; set; }
    }
}
