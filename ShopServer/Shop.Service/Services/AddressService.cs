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
    public class AddressService : Service<Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IGenericRepository<Address> repository, IUnitOfWork unitofWork, IAddressRepository addressRepository, IMapper mapper) : base(repository, unitofWork)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Address>> GetAddressAsync(int userId)
        {
            var addresses = await _addressRepository.GetAddress(userId).ToListAsync();
            if (addresses.Count <= 0)
            {
                throw new NotFoundException($"No User Id ({userId}) found from address");
            }
            return addresses;
        }
    }
}
