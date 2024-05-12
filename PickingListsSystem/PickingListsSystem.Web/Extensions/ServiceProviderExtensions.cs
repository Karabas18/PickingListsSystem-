using Microsoft.AspNetCore.Identity;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Extensions
{
    public static class ServiceProviderExtensions
    {
        public async static void DbInit(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var roleManager = scope.ServiceProvider.GetService<RoleManager<Role>>();

            if (roleManager != null && !roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role { Name = "User" });
                await roleManager.CreateAsync(new Role { Name = "Admin" });
            }
        }
    }
}
