using Microsoft.AspNetCore.Identity;

namespace PickingListsSystem.Entities
{
    public class User : IdentityUser
    {
        public string? Fullname { get; set; }

        public DateTime? Date { get; set; }
    }
}
