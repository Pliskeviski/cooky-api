using Cooky.API.Models;
using Cooky.Data;
using Cooky.Repositories.Base;

namespace Cooky.API.Repositories.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext) { }
    }
}
