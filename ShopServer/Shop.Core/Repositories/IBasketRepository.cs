using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
         IQueryable<Basket> GetSepets(int userId);

        Task<Basket> ProductIdAndUserId(Basket basket);
        Task<Basket> GetBasketByProductIdAndUserId(int userId, int productId);

    }
}
