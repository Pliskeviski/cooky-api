using webapi_learning.Data;
using webapi_learning.Models;
using webapi_learning.Repositories.Base;

namespace webapi_learning.Repositories
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(DataContext dbContext) : base(dbContext) { }
    }
}
