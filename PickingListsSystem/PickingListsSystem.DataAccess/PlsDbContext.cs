using Microsoft.EntityFrameworkCore;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess;

public class PlsDbContext : DbContext
{

    public PlsDbContext(DbContextOptions<PlsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Work> Work { get; set; }

    public virtual DbSet<Customer> Customer { get; set; }

    public virtual DbSet<WorkType> WorkType { get; set; }

    public virtual DbSet<Role> Role { get; set; }

}
