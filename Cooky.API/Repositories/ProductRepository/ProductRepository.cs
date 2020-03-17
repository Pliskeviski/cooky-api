using Cooky.API.Models;
using Cooky.Data;
using Cooky.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cooky.API.Repositories.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext dbContext, IConfiguration configuration) : base(dbContext, configuration) { }

        public async Task<List<Product>> GetProductByUserIdDapper(string userId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT * FROM Products WHERE userId = @uId";
                conn.Open();
                var result = await conn.QueryAsync<Product>(sQuery, new { uId = userId });
                return result.ToList();
            }
        }
    }
}
