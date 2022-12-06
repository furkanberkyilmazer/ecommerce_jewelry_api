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
    public class BasketService : Service<Basket>, IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofWork;
        public BasketService(IGenericRepository<Basket> repository, IUnitOfWork unitofWork, IBasketRepository basketRepository, IMapper mapper) : base(repository, unitofWork)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
            _unitofWork = unitofWork;
        }

      

        public async Task<IEnumerable<Basket>> GetSepetsAsync(int userId)
        {
            var baskets=await _basketRepository.GetSepets(userId).ToListAsync();
            if (baskets.Count<=0)
            {
                throw new NotFoundException($"No User Id ({userId}) found from basket");
            }
            return baskets;

        }

        public async Task<Basket> AddSepetsAsync(Basket basket)
        {
          var baskets= await _basketRepository.ProductIdAndUserId(basket);
          if (baskets==null)
          {
             await _basketRepository.AddAsync(basket);
             await _unitofWork.CommitAsync();
            return basket;

          }
          else
          {
                baskets.Piece += basket.Piece;
                _basketRepository.Update(baskets);
                _unitofWork.Commit();
                return baskets;

            }
          
           
        }

        public async Task<Basket> GetBasketByProductIdAndUserIdAsync(int userId,int productId)
        {
            var baskets = await _basketRepository.GetBasketByProductIdAndUserId(userId,productId);
            if (baskets == null)
            {
                throw new NotFoundException("There are no items in the cart");

            }
           
              
                return baskets;

            


        }
    }
}
