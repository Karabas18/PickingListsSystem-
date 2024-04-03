namespace PickingListsSystem.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string? UserFullname { get; set; }

        public string? UserEmail { get; set; }

        public DateTime? UserDate { get; set; }

        public ICollection<Role> Roles { get; set; }

        //public ICollection<Data> Data { get; set; }

        //public Role Role { get; set; }

        //public Data Data { get; set; }

    }
}
