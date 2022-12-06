using Shop.Core.DTOs;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Services
{
    public interface ICategoryService:IService<Category>

    {
        public  Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    }
}
