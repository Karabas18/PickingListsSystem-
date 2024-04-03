namespace PickingListsSystem.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string? UserFullname { get; set; }

        public string? UserEmail { get; set; }

        public DateTime? UserDate { get; set; }

        public Role Role { get; set; }

        public WorkGroup WorkGroup { get; set; }

        //public Data Data { get; set; }

    }
}
