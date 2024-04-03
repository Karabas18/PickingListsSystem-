namespace PickingListsSystem.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string? RoleName { get; set; }

        public int? RolePriority { get; set; }

        public User User { get; set; }
    }
}
