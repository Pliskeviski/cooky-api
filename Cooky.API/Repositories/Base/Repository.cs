using Cooky.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cooky.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly DbContext dbContext;
        private readonly IConfiguration _config;

        public Repository(DbContext context, IConfiguration config)
        {
            this.dbContext = context;
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
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
