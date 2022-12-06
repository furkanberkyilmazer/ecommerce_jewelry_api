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
    public class AddressController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IAddressService _addressService;

        public AddressController(IMapper mapper, IAddressService addressService)
        {
            _mapper = mapper;
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var addresses = await _addressService.GetAllAsync();
            var addressesDtos = _mapper.Map<List<AddressDto>>(addresses.ToList());
            return CreateActionResult(CustomResponseDto<List<AddressDto>>.Succes(200, addressesDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(AddressDto addressDto)
        {
            var address = await _addressService.AddAsync(_mapper.Map<Address>(addressDto));
            var addressesDto = _mapper.Map<AddressDto>(address);

            return CreateActionResult(CustomResponseDto<AddressDto>.Succes(201, addressesDto));
        }

        // Delete / api / baskets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var address = await _addressService.GetByIdAsync(id);




            await _addressService.RemoveAsync(address);


            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [HttpPut]
        public async Task<IActionResult> Update(AddressDto addressDto)
        {
            await _addressService.UpdateAsync(_mapper.Map<Address>(addressDto));


            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }
        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetAddresses(int userId)
        {
            var addresses = await _addressService.GetAddressAsync(userId);
            var addressesDtos = _mapper.Map<List<AddressDto>>(addresses.ToList());
            return CreateActionResult(CustomResponseDto<List<AddressDto>>.Succes(200, addressesDtos));
        }

        [HttpGet("{addressId}")]
        public async Task<IActionResult> GetAddressesById(int addressId)
        {
            var addresse = await _addressService.GetByIdAsync(addressId);
            var addresseDtos = _mapper.Map<AddressDto>(addresse);
            return CreateActionResult(CustomResponseDto<AddressDto>.Succes(200, addresseDtos));
        }

    }
}
