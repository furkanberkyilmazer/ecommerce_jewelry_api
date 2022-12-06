using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.DTOs;
using Shop.Core.Models;
using Shop.Core.Services;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public OrdersController(IOrderService orderService, IMapper mapper, IBasketService basketService, IProductService productService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _basketService = basketService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var orders = await _orderService.GetAllAsync();
            var ordersDtos = _mapper.Map<List<OrderDto>>(orders.ToList());
            return CreateActionResult(CustomResponseDto<List<OrderDto>>.Succes(200, ordersDtos.ToList()));
        }

        [HttpPost]
        public async Task<IActionResult> Save(OrderDto orderDto)
        {

            var order = await _orderService.CreateOrderAsync(_mapper.Map<Order>(orderDto));
            var ordersDto = _mapper.Map<OrderDto>(order);
           /* var baskets = await _basketService.GetBasketByProductIdAndUserIdAsync(order.UserId, order.ProductId);
            
            var basket = await _basketService.GetByIdAsync(baskets.Id);
            await _basketService.RemoveAsync(basket);*/

            return CreateActionResult(CustomResponseDto<OrderDto>.Succes(201, ordersDto));
        }

        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetOrders(int userId)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            var ordersDtos = _mapper.Map<List<OrderDto>>(orders.ToList());
            return CreateActionResult(CustomResponseDto<List<OrderDto>>.Succes(200, ordersDtos));
        }
    }
}
