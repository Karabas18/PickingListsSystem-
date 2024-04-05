namespace PickingListsSystem.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string? RoleName { get; set; }

        public int? RolePriority { get; set; }

        public ICollection<User> User { get; set; }
    }
}
