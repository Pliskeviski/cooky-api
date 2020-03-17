using AutoMapper;
using Cooky.API.DTOs.ProductDTO;
using Cooky.API.Models;
using Cooky.API.Models.Enum;
using Cooky.API.Repositories.ProductRepository;
using Cooky.API.Repositories.UserRepository;
using Cooky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cooky.API.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly IUserRepository _userRepository;
        public ProductService(IMapper mapper, IProductRepository productRepository, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._repository = productRepository;
            this._userRepository = userRepository;
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

        public async Task<ServiceResponse<List<GetProductDTO>>> GetNearbyProducts(GetNearByDTO location)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDTO>>();

            try
            {
                List<User> nearByUsers = await _userRepository.GetNearByDapper(location.Latitude, location.Longitude);

                List<Product> products = new List<Product>();
                nearByUsers.ForEach((usr) => {
                    var userProducts = _repository.GetProductByUserIdDapper(usr.Id).Result;
                    var activeProducts = userProducts.Where(x => x.Status == ProductStatus.Active).ToList();
                    activeProducts.ForEach(x => x.User = usr);
                    products.AddRange(activeProducts);
                });

                serviceResponse.Data = _mapper.Map<List<GetProductDTO>>(products);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDTO>> GetProduct(string id)
        {
            var serviceResponse = new ServiceResponse<GetProductDTO>();

            try
            {
                serviceResponse.Data = _mapper.Map<GetProductDTO>(await _repository.GetByIdAsync(id));
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
