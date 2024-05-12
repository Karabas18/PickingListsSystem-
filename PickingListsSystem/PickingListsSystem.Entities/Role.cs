using Microsoft.AspNetCore.Identity;

namespace PickingListsSystem.Entities
{
    public class Role: IdentityRole
    {
        public string? RoleName { get; set; }

        public int? RolePriority { get; set; }
    }
}
