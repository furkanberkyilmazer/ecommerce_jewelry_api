﻿using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Services
{
    public interface IAddressService : IService<Address>
    {
        Task<IEnumerable<Address>> GetAddressAsync(int userId);
    }
}
