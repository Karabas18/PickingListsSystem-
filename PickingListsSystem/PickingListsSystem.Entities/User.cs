namespace PickingListsSystem.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string? Fullname { get; set; }

        public string? Email { get; set; }

        public DateTime? Date { get; set; }

        public Role Role { get; set; }

        //public WorkGroup WorkGroup { get; set; }

        //public UserData UserData { get; set; }

    }
}
