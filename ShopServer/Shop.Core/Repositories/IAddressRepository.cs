using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        IQueryable<Address> GetAddress(int userId);
    }
}
