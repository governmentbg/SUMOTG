using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class OditRepository : IOditRepository
    {
        private readonly DataContext _dbContext;

        public OditRepository(DataContext context)
        {
            _dbContext = context;
        }

        public async Task<int> AddRow(int id, string text, string iduser)
        {
            var item = new OditLog
            {
                Koga = DateTime.Now,
                User = iduser,
                Kod = id,
                Text = text,
            };

            _dbContext.Entry(item).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> DeleteRows(DateTime from, DateTime To)
        {
            _dbContext.OditLog
                        .RemoveRange(_dbContext.OditLog
                                            .Where(x => x.Koga >= from && x.Koga <= To));
            await _dbContext.SaveChangesAsync();
            return 1;
        }

//       public async  Task<IList<ViewOditLog>> GetOditLog(DateTime from, DateTime To, string iduser);

    }
}
