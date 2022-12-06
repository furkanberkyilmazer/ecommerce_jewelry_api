using Shop.Core.DTOs;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task BlokeAsync(int id);

        Task<User> LoginAsync(string userNameOrEmail, string password);

        Task<bool> EmailCheckAsync(string email);

        Task<bool> UsernameCheckAsync(string username);
    }
}
