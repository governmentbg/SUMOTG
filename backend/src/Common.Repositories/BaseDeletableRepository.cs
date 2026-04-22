using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DataAccess.EFCore;
using Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Common.Repositories
{
    public abstract class BaseDeletableRepository<TType, TContext>
        where TType : DeletableEntity, new()
        where TContext : DataContext
    {
        public readonly TContext _dbContext;

        protected BaseDeletableRepository(TContext context)
        {
            _dbContext = context;
        }

        protected IQueryable<TType> GetEntities(bool includeDeleted = false)
        {
            var query = _dbContext.Set<TType>().AsQueryable();
            if (!includeDeleted)
            {
                query = query.Where(obj => !obj.IsDeleted);
            }

            return query.AsNoTracking();
        }

        public virtual async Task<IEnumerable<TType>> GetList(bool includeDeleted = false)
        {
            return await GetEntities(includeDeleted).ToListAsync();
        }

        public virtual async Task<TType> Get(int id,bool includeDeleted = false)
        {
            return await GetEntities(includeDeleted).Where(obj => obj.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<bool> Exists(TType obj,bool includeDeleted = false)
        {
            return await GetEntities(includeDeleted).Where(x => x.Id == obj.Id).CountAsync() > 0;
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
            var itemToDelete = new TType {Id = id, IsDeleted = true};
            _dbContext.Entry(itemToDelete).Property(obj => obj.IsDeleted).IsModified = true;
            await _dbContext.SaveChangesAsync();
        }
    }
}