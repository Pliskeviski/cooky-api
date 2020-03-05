using AutoMapper;
using Cooky.API.DTOs.ProductDTO;
using Cooky.API.Models;
using Cooky.API.Repositories.ProductRepository;
using Cooky.Models;
using System;
using System.Threading.Tasks;

namespace Cooky.API.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            this._mapper = mapper;
            this._repository = productRepository;
        }

        public async Task<ServiceResponse<GetProductDTO>> AddProduct(AddProductDTO newProduct, User user)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();

            try
            {
                newProduct.UserId = user.Id;
                Product product = _mapper.Map<Product>(newProduct);
                product.Price = product.OriginalPrice;

                await _repository.AddAsync(product);

                serviceResponse.Data = _mapper.Map<GetProductDTO>(await _repository.SingleOrDefaultAsync(x => x.Id == product.Id));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
