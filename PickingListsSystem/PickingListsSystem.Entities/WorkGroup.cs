namespace PickingListsSystem.Entities
{
    public class WorkGroup
    {
        public int Id { get; set; }

        public string? WorkGroupStructure { get; set; }

        public string? WorkGroupDirectorName { get; set; }
        public User? WorkGroupDirector { get; set; }
        
        public List<User> Users { get; set; } = new List<User>();

        public List<Project> Projects { get; set; } = new List<Project>();

    }
}
