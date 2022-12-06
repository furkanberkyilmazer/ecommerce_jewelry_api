using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Services
{
    public interface IBasketService : IService<Basket>
    {

        Task<IEnumerable<Basket>> GetSepetsAsync(int userId);

        Task<Basket> GetBasketByProductIdAndUserIdAsync(int userId, int productId);

        Task<Basket> AddSepetsAsync(Basket basket);
    }
}
