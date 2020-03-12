using System.Collections.Generic;
using System.Data;
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

        public async Task<List<User>> GetNearByDapper(double latitude, double longitude, float rangeDistance)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT * FROM Users where 
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
