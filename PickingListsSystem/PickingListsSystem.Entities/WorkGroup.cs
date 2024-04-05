namespace PickingListsSystem.Entities
{
    public class WorkGroup
    {
        public int Id { get; set; }

        public string? WorkGroupStructure { get; set; }
        public int? WorkGroupDirectorId { get; set; }
        public User? WorkGroupDirector { get; set; }
        
        public List<User> Users { get; set; }

        public List<Project> Projects { get; set; }

    }
}
