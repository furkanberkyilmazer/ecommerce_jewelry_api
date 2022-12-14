using Microsoft.EntityFrameworkCore;
using Shop.Core.Models;
using Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public void Block(int id)
        {
            var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null) return;
            user.RoleId = 3;
            _context.Update(user);
        }

        public async Task<bool> EmailCheckAsync(string email)
        {
           
            return await _context.Users.AnyAsync(x => x.Email == email);    
        }

        public async Task<User> LoginAsync(string userNameOrEmail, string password)
        {
            
            return await _context.Users.Where(x => (x.Username == userNameOrEmail || x.Email == userNameOrEmail) && x.Password == password).FirstOrDefaultAsync();
        }

    
        public  async Task<bool> UsernameCheckAsync(string username)
        {
           return await _context.Users.AnyAsync(x => x.Username == username);
        }
    }
}
