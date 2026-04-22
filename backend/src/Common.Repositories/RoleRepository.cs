/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class RoleRepository: BaseRepository<Role, DataContext>, IRoleRepository<Role>
    {
        public RoleRepository(DataContext context) : base(context)
        {
        }

        public async Task<Role> Get(string name)
        {
            return await GetEntities()
                .Where(obj => obj.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Role>>  GetRoles(bool includeDeleted = false)
        {
            return await GetEntities().ToListAsync();
        }
    }
}