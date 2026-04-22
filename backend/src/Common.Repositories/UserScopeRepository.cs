
using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class UserScopeRepository : IUserScopeRepository<UserObhvat>
    {
        private readonly DataContext _dbContext;

        public UserScopeRepository(DataContext context)
        {
            _dbContext = context;
        }

        public async Task<UserObhvat> Add(UserObhvat userScope)
        {
            _dbContext.Entry(userScope).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(userScope).Reference(ur => ur.Obhvat).LoadAsync();
            return userScope;
        }

        public async Task Delete(int userId)
        {
            _dbContext.UserObhvat.RemoveRange(_dbContext.UserObhvat.Where(x => x.UserId == userId));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserObhvat> Get(int userId, int scopeId)
        {
            return await _dbContext.Set<UserObhvat>()
                .AsNoTracking()
                .Where(obj => obj.ObhvatId == scopeId && obj.UserId == userId)
                .FirstOrDefaultAsync();
        }
    }
}