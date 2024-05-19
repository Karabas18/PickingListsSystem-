namespace PickingListsSystem.Entities
{
    public class Statement
    {
        public int Id { get; set; }

        public string? StatementStatus { get; set; }

        public DateTime? StatementDate { get; set; }

        //public string? UserId { get; set; }

        //public User User { get; set; }

        public Project Project { get; set; } //Один-ко-многим

        public int ProjectId { get; set; }

        public List<Material> Materials { get; set; } = new(); //Один-ко-многим

        public Work Work { get; set; }

        public int WorkId { get; set; }

        //public ICollection<Material> Materials { get; set; } = new List<Material>();

        //public ICollection<Work> Work { get; set; } = new List<Work>();
    }
}
