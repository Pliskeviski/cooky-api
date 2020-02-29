using Cooky.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cooky.Data;
using Cooky.Repositories.Base;

namespace Cooky.API.Repositories.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext) { }
    }
}
