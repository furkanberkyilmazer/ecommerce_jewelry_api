using Shop.Core.DTOs;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWitCategoryAsync();

        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    }
}
