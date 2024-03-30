using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PickingListsSystem.DataAccess;

namespace PickingListsSystem.DataAccess
{
    public class PlsDbContextFactory : IDesignTimeDbContextFactory<PlsDbContext>
    {
        public PlsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PlsDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-PDBP6QI\\SQLEXPRESS;Initial Catalog=PickingListDataBase;Integrated Security=True;TrustServerCertificate=True;");

            return new PlsDbContext(optionsBuilder.Options);
        }
    }
}
