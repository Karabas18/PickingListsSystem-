namespace PickingListsSystem.Entities
{
    public class UserData
    {
        public int Id { get; set; }

        public byte[]? UserHashLogin { get; set; }

        public byte[]? UserHashPassword { get; set; }

        public User User { get; set; }
    }
}
