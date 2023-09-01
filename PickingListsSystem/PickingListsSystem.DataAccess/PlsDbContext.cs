using Microsoft.EntityFrameworkCore;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess;

public class PlsDbContext : DbContext
{
    public PlsDbContext()
    {
    }

    public PlsDbContext(DbContextOptions<PlsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Material> Materials { get; set; }


}
