using Cooky.API.Models;
using Cooky.Data;
using Cooky.Repositories.Base;

namespace Cooky.API.Repositories.LoginRepository
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        public LoginRepository(DataContext dbContext) : base(dbContext) { }
    }
}
