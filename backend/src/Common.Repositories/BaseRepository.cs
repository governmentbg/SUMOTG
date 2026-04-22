/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using System.Collections.Generic;
using System.Linq;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Common.DataAccess.EFCore;

namespace Common.Repositories
{
    public abstract class BaseRepository<TType, TContext>
        where TType : BaseEntity, new()
        where TContext : DataContext
    {
        
        protected readonly TContext _dbContext;

        protected BaseRepository(TContext context)
        {
            _dbContext = context;
        }

        protected IQueryable<TType> GetEntities()
        {
            return _dbContext.Set<TType>().AsQueryable().AsNoTracking();
        }

        public virtual async Task<IEnumerable<TType>> GetList()
        {
            return await GetEntities().ToListAsync();
        }

        public virtual async Task<TType> Get(int id)
        {
            return await GetEntities()
                .Where(obj => obj.Id == id)
                .FirstOrDefaultAsync();
        }

        public virtual async Task<bool> Exists(TType obj)
        {
            return await GetEntities()
                       .Where(x => x.Id == obj.Id)
                       .CountAsync() > 0;
        }

        public virtual async Task<TType> Edit(TType obj)
        {
            var objectExists = await Exists(obj);
            _dbContext.Entry(obj).State = objectExists ? EntityState.Modified : EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public virtual async Task Delete(int id)
        {
            var itemToDelete = new TType {Id = id};
            _dbContext.Entry(itemToDelete).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}