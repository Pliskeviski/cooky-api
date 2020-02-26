using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace webapi_learning.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;

        public Repository(DbContext context)
        {
            this.dbContext = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(TEntity entities)
        {
            await dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task Update(TEntity entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
