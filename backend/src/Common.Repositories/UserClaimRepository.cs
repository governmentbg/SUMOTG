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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class UserClaimRepository: IUserClaimRepository<UserClaim>
    {
        private readonly DataContext _dbContext;

        public UserClaimRepository(DataContext context)
        {
            _dbContext = context;
        }

        public async Task<UserClaim> Add(UserClaim userClaim)
        {
            _dbContext.Entry(userClaim).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return userClaim;
        }

        public async Task<IList<UserClaim>> EditMany(IList<UserClaim> userClaims)
        {
            foreach (var uc in userClaims)
            {
                _dbContext.Entry(uc).State = EntityState.Modified;
            }

            await _dbContext.SaveChangesAsync();

            return userClaims;
        }

        public async Task Delete(int userId, string claimType, string claimValue)
        {
            var itemsToDelete = await _dbContext.Set<UserClaim>()
                .Where(cl => cl.UserId == userId && cl.ClaimType == claimType && cl.ClaimValue == claimValue)
                .ToListAsync();
            _dbContext.Set<UserClaim>().RemoveRange(itemsToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<UserClaim>> GetByUserId(int userId)
        {
            var list = await _dbContext.Set<UserClaim>()
                .AsNoTracking()
                .Where(obj => obj.UserId == userId)
                .ToListAsync();

            return list.ToList();
        }

        public async Task<IList<UserClaim>> GetList(int userId, string claimType, string claimValue)
        {
            return await _dbContext.Set<UserClaim>()
                .AsNoTracking()
                .Where(obj => obj.UserId == userId && obj.ClaimType == claimType && obj.ClaimValue == claimValue)
                .ToListAsync();
        }
    }
}