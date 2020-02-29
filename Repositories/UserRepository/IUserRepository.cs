using Cooky.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cooky.Repositories.Base;

namespace Cooky.API.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
