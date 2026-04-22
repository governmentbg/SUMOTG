/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class SettingsRepository : BaseRepository<Settings, DataContext>, ISettingsRepository
    {

        public SettingsRepository(DataContext context) : base(context) { }

        public override async Task<bool> Exists(Settings obj)
        {
            return await _dbContext.Settings.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public override async Task<Settings> Get(int id)
        {
            return await _dbContext.Settings.Where(obj => obj.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
