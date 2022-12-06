using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofWork;
        public OrderService(IGenericRepository<Order> repository, IUnitOfWork unitofWork, IOrderRepository orderRepository, IMapper mapper) : base(repository, unitofWork)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _unitofWork = unitofWork;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _orderRepository.CreateOrderAsync(order);
            await _unitofWork.CommitAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserId(userId).ToListAsync();
            if (orders.Count <= 0)
            {
                throw new NotFoundException($"No User Id ({userId}) found from basket");
            }
            return orders;
        }
    }
}
