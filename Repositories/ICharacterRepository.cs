using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_learning.Models;
using webapi_learning.Repositories.Base;

namespace webapi_learning.Repositories
{
    public interface ICharacterRepository : IRepository<Character>
    {
    }
}
