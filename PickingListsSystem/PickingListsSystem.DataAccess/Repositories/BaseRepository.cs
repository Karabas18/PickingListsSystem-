using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickingListsSystem.DataAccess.Repositories
{
    public class BaseRepository
    {
        protected PlsDbContext _dbContext;

        public BaseRepository(PlsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
