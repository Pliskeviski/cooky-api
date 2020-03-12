using Cooky.API.Models;
using Cooky.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooky.API.Repositories.ProductRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProductByUserIdDapper(string userId);
    }
}
