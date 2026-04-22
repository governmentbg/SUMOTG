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
    public class UserRoleRepository : IUserRoleRepository<UserRole>
    {
        private readonly DataContext _dbContext;

        public UserRoleRepository(DataContext context)
        {
            _dbContext = context;
        }

        public async Task<UserRole> Add(UserRole userRole)
        {
            _dbContext.Entry(userRole).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(userRole).Reference(ur => ur.Role).LoadAsync();
            return userRole;
        }

        public async Task Delete(int userId)
        {
            _dbContext.UserRoles.RemoveRange(_dbContext.UserRoles.Where(x => x.UserId == userId));
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int userId, int roleId)
        {
            var itemToDelete = new UserRole { UserId = userId, RoleId = roleId };
            _dbContext.Entry(itemToDelete).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserRole> Get(int userId, int roleId)
        {
            return await _dbContext.Set<UserRole>()
                .AsNoTracking()
                .Where(obj => obj.RoleId == roleId && obj.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<string>> GetByUserId(int userId)
        {
            return await _dbContext.Set<UserRole>()
                .AsNoTracking()
                .Where(obj => obj.UserId == userId)
                .Include(obj => obj.Role)
                .Select(obj => obj.Role.Name)
                .ToListAsync();
        }
    }
}