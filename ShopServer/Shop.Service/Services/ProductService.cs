using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Core.DTOs;
using Shop.Core.Models;
using Shop.Core.Repositories;
using Shop.Core.Services;
using Shop.Core.UnitOfWorks;
using Shop.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitofWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitofWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryId(categoryId).ToListAsync();
            if (products.Count <= 0)
            {
                throw new NotFoundException($"No category Id ({categoryId}) found from products");
            }
            return products;

        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWitCategoryAsync()
        {
            var products = await _productRepository.GetProductsWitCategoryAsync(); 
            var productsDto=_mapper.Map <List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Succes(200, productsDto);
        }
    }
}
