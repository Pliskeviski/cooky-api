using Cooky.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cooky.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly DbContext dbContext;

        public Repository(DbContext context)
        {
            this.dbContext = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.CreateAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

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

        public async ValueTask<TEntity> GetByIdAsync(string id)
        {
            return await dbContext.Set<TEntity>().Where(x => x.Id == id && x.DeletedAt == null).FirstOrDefaultAsync();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var entity = await GetByIdAsync(id);
            entity.DeletedAt = DateTime.UtcNow;
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
