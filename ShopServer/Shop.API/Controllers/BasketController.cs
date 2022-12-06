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
    public class BasketController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IBasketService _basketService;

        public BasketController(IMapper mapper, IBasketService basketService)
        {
            _mapper = mapper;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var baskets = await _basketService.GetAllAsync();
            var basketsDtos = _mapper.Map<List<BasketDto>>(baskets.ToList());
            return CreateActionResult(CustomResponseDto<List<BasketDto>>.Succes(200, basketsDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BasketDto basketDto)
        {
            var basket = await _basketService.AddAsync(_mapper.Map<Basket>(basketDto));
            var basketsDto = _mapper.Map<BasketDto>(basket);

            return CreateActionResult(CustomResponseDto<BasketDto>.Succes(201, basketsDto));
        }

        // Delete / api / baskets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var basket = await _basketService.GetByIdAsync(id);

          


            await _basketService.RemoveAsync(basket);


            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BasketDto basketDto)
        {
            await _basketService.UpdateAsync(_mapper.Map<Basket>(basketDto));


            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }
        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetSepets(int userId)
        {
            var baskets = await _basketService.GetSepetsAsync(userId);
            var basketsDtos = _mapper.Map<List<BasketDto>>(baskets.ToList());
            return CreateActionResult(CustomResponseDto<List<BasketDto>>.Succes(200, basketsDtos));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddSepet(BasketDto basketDto)
        {
            var basket = await _basketService.AddSepetsAsync(_mapper.Map<Basket>(basketDto));                     
            var basketsDto = _mapper.Map<BasketDto>(basket);
            return CreateActionResult(CustomResponseDto<BasketDto>.Succes(201, basketsDto));
        }

        [HttpGet("[action]/{userId}/{productId}")]
        public async Task<IActionResult> GetSepetByUserIdAndProductId(int userId , int productId)
        {
            var baskets = await _basketService.GetBasketByProductIdAndUserIdAsync(userId,productId);
            var basketsDtos = _mapper.Map<BasketDto>(baskets);
            return CreateActionResult(CustomResponseDto<BasketDto>.Succes(200, basketsDtos));
        }

        [HttpGet("{id}")] //burda if vermezsek sadece aşağıdaki parametre olursa ?id=5 diye beklerdi
        public async Task<IActionResult> GetById(int id)
        {
            var basket = await _basketService.GetByIdAsync(id);
            var basketDto = _mapper.Map<BasketDto>(basket);

            return CreateActionResult(CustomResponseDto<BasketDto
                >.Succes(200, basketDto));
        }


    }
}
