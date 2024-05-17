namespace PickingListsSystem.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerContactPercon { get; set; }

        public string? CustomerPhone { get; set; }

        public string? CustomerEmail { get; set; }

        public ICollection<Project> Project { get; set; } = new List<Project>();//правильно?

    }
}