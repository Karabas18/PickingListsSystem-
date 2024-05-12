namespace PickingListsSystem.Dto.User
{
    public class RefreshTokenRequest
    {
        public string AuthenticationToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
