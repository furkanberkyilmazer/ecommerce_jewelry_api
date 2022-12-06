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
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Basket> GetBasketByProductIdAndUserId(int userId, int productId)
        {
            return await _context.Baskets.Where(x => x.UserId == userId && x.ProductId == productId).FirstOrDefaultAsync();
        }

        public  IQueryable<Basket> GetSepets(int userId)
        {
            return _context.Baskets.Where(x => x.UserId == userId);
        }

      
        public async Task<Basket> ProductIdAndUserId(Basket basket)
        {
            return  _context.Baskets.Where(x => x.UserId == basket.UserId && x.ProductId==basket.ProductId).FirstOrDefault();
        }
    }
}
