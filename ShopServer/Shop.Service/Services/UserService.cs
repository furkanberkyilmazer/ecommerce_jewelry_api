using AutoMapper;
using Shop.Core.DTOs;
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
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofWork;

        public UserService(IGenericRepository<User> repository, IUnitOfWork unitofWork, IUserRepository userRepository, IMapper mapper) : base(repository, unitofWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitofWork = unitofWork;   
        }

        public async Task BlokeAsync(int id)
        {
            _userRepository.Block(id);
            _unitofWork.CommitAsync();



        }

        public async Task<User> LoginAsync(string userNameOrEmail, string password)
        {

            var user = await _userRepository.LoginAsync(userNameOrEmail,password);
            if (user == null)
            {
                throw new NotFoundException($"{typeof(User).Name} {userNameOrEmail} not found");
            }
            return user;
        }

        public async Task<bool> EmailCheckAsync(string email)
        {

            return await _userRepository.EmailCheckAsync(email);
          
        }

       

        public async Task<bool> UsernameCheckAsync(string username)
        {
            return await _userRepository.UsernameCheckAsync(username);
         
          
        }
    }
}
