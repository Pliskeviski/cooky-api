using Cooky.API.Models;
using Cooky.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooky.API.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetNearByDapper(double latitude, double longitude, float rangeDistance = 20);
    }
}
