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
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
 
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllAsync();
            var usersDtos = _mapper.Map<List<UserDto>>(users.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Succes(200,usersDtos));

       
        }

        [HttpGet("{id}")] //burda if vermezsek sadece aşağıdaki parametre olursa ?id=5 diye beklerdi
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);

            return CreateActionResult(CustomResponseDto<UserDto>.Succes(200, userDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var user = await _userService.AddAsync(_mapper.Map<User>(userDto));
            var usersDto = _mapper.Map<UserDto>(user);

            return CreateActionResult(CustomResponseDto<UserDto>.Succes(201, usersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(userDto));


            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "bu Id ye sahip ürün bulunamadı."));


            await _userService.RemoveAsync(user);


            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Bloke(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if(user != null)
            await _userService.BlokeAsync(id);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [HttpGet("[action]/{userNameOrEmail}/{password}")]
        public async Task<IActionResult> Login(string userNameOrEmail,string password)
        {
           var users = await _userService.LoginAsync(userNameOrEmail,password);
           var usersDtos = _mapper.Map<UserDto>(users);
           return CreateActionResult(CustomResponseDto<UserDto>.Succes(200, usersDtos));
          


        }

        [HttpGet("[action]/{Email}")]
        public async Task<IActionResult> EmailCheck(string Email)
        {


            var users = await _userService.EmailCheckAsync(Email);
            return CreateActionResult(CustomResponseDto<bool>.Succes(200,users));



        }

        [HttpGet("[action]/{Username}")]
        public async Task<IActionResult> UsernameCheck(string Username)
        {


            var users = await _userService.UsernameCheckAsync(Username);
            return CreateActionResult(CustomResponseDto<bool>.Succes(200, users));



        }



    }
}
