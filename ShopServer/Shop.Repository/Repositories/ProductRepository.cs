using Microsoft.EntityFrameworkCore;
using Shop.Core.Models;
using Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _context.Products.Where(x => x.CategoryId == categoryId);
        }

        public async Task<List<Product>> GetProductsWitCategoryAsync()
        {
            //Eager Loading
           return await _context.Products.Include(x=>x.Category).ToListAsync(); 
        }
    }
}
