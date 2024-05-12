namespace PickingListsSystem.Entities
{
    public class UserRefreshToken
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime IssuedUtc { get; set; }

        public DateTime ExpiresUtc { get; set; }

        public string? RefreshToken { get; set; }

        public string? UserId { get; set; }
    }
}
