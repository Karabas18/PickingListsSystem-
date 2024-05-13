using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess;

public class PlsDbContext : IdentityDbContext
{

    public PlsDbContext(DbContextOptions<PlsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Work> Work { get; set; }

    public virtual DbSet<Customer> Customer { get; set; }

    public virtual DbSet<WorkType> WorkType { get; set; }

    public virtual DbSet<Role> Role { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<WorkGroup> WorkGroup { get; set; }

    public virtual DbSet<Project> Project { get; set; }

    public virtual DbSet<Statement> Statement { get; set; }
}
