
using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class ObhvatRepository : BaseRepository<Obhvat, DataContext>, IObhvatRepository<Obhvat>
    {
        public ObhvatRepository(DataContext context) : base(context)
        {
        }

        public async Task<IList<Obhvat>> GetObhvats(bool includeDeleted = false)
        {
            return await GetEntities().ToListAsync();
        }
    }
}
