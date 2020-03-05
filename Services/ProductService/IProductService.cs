﻿using Cooky.API.DTOs.ProductDTO;
using Cooky.API.Models;
using Cooky.Models;
using System.Threading.Tasks;

namespace Cooky.API.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<GetProductDTO>> AddProduct(AddProductDTO newProduct, User user);
    }
}
