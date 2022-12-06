using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        void Block(int id);

        Task<User> LoginAsync(string userNameOrEmail,string password);

        Task<bool> EmailCheckAsync(string email);

        Task<bool> UsernameCheckAsync(string username);

    }
}
