using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PickingListsSystem.DataAccess;

public static class PlsDBServiceBuilderExtensions
{
    public static void MigratePls(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        using var db = scope.ServiceProvider.GetRequiredService<PlsDbContext>();
        db.Database.Migrate();
    }
}