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
    public class IdentityUserRepository: BaseDeletableRepository<User, DataContext>, IIdentityUserRepository<User>
    {

        public IdentityUserRepository(DataContext context) : base(context)
        {
        }

        public override async Task<User> Get(int id, bool includeDeleted = false)
        {
            return await GetEntities()
                .Where(obj => obj.Id == id )
                .Include(u => u.Claims)
                .Include(u => u.UserRoles)
                .ThenInclude(x => x.Role)
                .Include(u => u.UserObhvat)
                .ThenInclude(x => x.Obhvat)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetByLogin(string login, bool includeDeleted = false)
        {
            return await GetEntities()
                .Where(obj => obj.Login == login && !obj.IsDeleted && obj.status == 1)
                .Include(u => u.Claims)
                .Include(u => u.UserRoles)
                .ThenInclude(x => x.Role)
                .Include(u => u.UserObhvat)
                .ThenInclude(x => x.Obhvat)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmail(string email, bool includeDeleted = false)
        {
            return await GetEntities()
                .Include(u => u.UserRoles)
                .ThenInclude(x => x.Role)
                .Include(u => u.Claims)
                .Include(u => u.UserObhvat)
                .ThenInclude(x => x.Obhvat)
                .Where(obj => obj.Email == email && !obj.IsDeleted && obj.status == 1)
                .FirstOrDefaultAsync();
        }

        public Task<User> GetById(int id, bool includeDeleted = false)
        {
            return Get(id);
        }

        public async Task<IList<User>> GetUsersByRole(int roleId, bool includeDeleted = false)
        {
            return await GetEntities()
                .Include(u => u.Claims)
                .Include(u => u.UserRoles)
                .ThenInclude(x => x.Role)
                .Include(u => u.UserObhvat)
                .ThenInclude(x => x.Obhvat)
                .Where(x => x.UserRoles.Any(ur => ur.RoleId == roleId))
                .ToArrayAsync();
        }

        public async Task<IList<User>> GetUsersByClaim(string claimType, string claimValue,
            bool includeDeleted = false)
        {
            return await GetEntities()
                .Include(u => u.Claims)
                .Include(u => u.UserRoles)
                .ThenInclude(x => x.Role)
                .Include(u => u.UserObhvat)
                .ThenInclude(x => x.Obhvat)
                .Where(x => x.Claims.Any(cl => cl.ClaimType == claimType && cl.ClaimValue == claimValue))
                .ToArrayAsync();
        }
    }
}