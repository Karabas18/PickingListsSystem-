namespace PickingListsSystem.Entities
{
    public class Statement
    {
        public int Id { get; set; }

        public string? StatementStatus { get; set; }

        public DateTime? StatementDate { get; set; }

        //public string? UserId { get; set; }

        //public User User { get; set; }

        public ICollection<Project> Project { get; set; } = new List<Project>();

        public ICollection<Material> Materials { get; set; } = new List<Material>();
        
        public ICollection<Work> Work { get; set; } = new List<Work>();
    }
}
