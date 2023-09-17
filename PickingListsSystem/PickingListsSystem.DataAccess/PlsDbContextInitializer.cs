using Microsoft.EntityFrameworkCore;

namespace PickingListsSystem.DataAccess;

public class PlsDbContextInitializer
{
    private readonly PlsDbContext context;


    public PlsDbContextInitializer(PlsDbContext context)
    {
        this.context = context;
    }

    public void Seed()
    {
        context.Database.Migrate();
    }
}
