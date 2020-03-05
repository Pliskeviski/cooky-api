using Cooky.API.Models;
using Cooky.API.Repositories.UserRepository;
using Cooky.Data;
using Cooky.Repositories.Base;

namespace Cooky.API.Repositories.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext dbContext) : base(dbContext) { }
    }
}
