using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Cooky.API.Models;
using Cooky.Data;
using Cooky.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Cooky.API.Repositories.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext, IConfiguration configuration) : base(dbContext, configuration) { }

        public async Task<User> GetByIdWithProductsDapper(string id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT * FROM Users 
                                  WHERE DeletedAt IS NULL AND Id = @uId";
                conn.Open();
                var result = await conn.QueryAsync<User>(sQuery, new { uId = id });
                var user = result.FirstOrDefault();
                
                if(user != null)
                {
                    string ssQuery = @"SELECT * FROM Products 
                                       WHERE UserId = @uId";
                    var resultProducts = await conn.QueryAsync<Product>(ssQuery, new { uId = id });
                    user.Products = resultProducts.ToList();
                }

                return user;
            }
        }

        public async Task<List<User>> GetNearByDapper(double latitude, double longitude, float rangeDistance)
        {
            using (IDbConnection conn = Connection)
            { 
                string sQuery = @"SELECT * FROM Users where 
                                  DeletedAt IS NULL AND
                                  (111.045 * DEGREES(ACOS(COS(RADIANS(@lat))
                                  * COS(RADIANS(Latitude))
                                  * COS(RADIANS(Longitude) - RADIANS(@lng))
                                  + SIN(RADIANS(@lat))
                                  * SIN(RADIANS(Latitude))))) < @range";
                conn.Open();
                var result = await conn.QueryAsync<User>(sQuery, new { lat = latitude, lng = longitude, range = rangeDistance });
                return result.ToList();
            }
        }
    }
}
