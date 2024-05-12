using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PickingListsSystem.Dto.Infrastructure
{
    public class JwtSettings
    {
        public int Lifetime { get; set; }
        public int RefreshLifetime { get; set; } = 60 * 24 * 30; // 30d
        public string? SecretKey { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        }

        public DateTime GetRefreshLifetime(DateTime utcNow)
        {
            return utcNow.AddMinutes(RefreshLifetime);
        }
    }
}
