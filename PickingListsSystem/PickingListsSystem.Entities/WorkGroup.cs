namespace PickingListsSystem.Entities
{
    public class WorkGroup
    {
        public int Id { get; set; }

        public string? WorkGroupStructure { get; set; }

        public User? WorkGroupDirector { get; set; }

        public ICollection<User> User { get; set; }

    }
}
