using AutoMapper;
using Shop.Core.DTOs;
using Shop.Core.Models;
using Shop.Core.Repositories;
using Shop.Core.Services;
using Shop.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitofWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitofWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductAsync(int categoryId)
        {
            var category= await _categoryRepository.GetSingleCategoryByIdWithProductAsync(categoryId);

            var categoryDto= _mapper.Map<CategoryWithProductsDto>(category);
            return  CustomResponseDto<CategoryWithProductsDto>.Succes(200, categoryDto); 
        }
    }
}
