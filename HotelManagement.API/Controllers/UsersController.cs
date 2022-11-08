using HotelManagement.API.ViewModel;
using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        // Register User 
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.ProfilePic))
            {
                vm.ProfilePic = "https://img.freepik.com/free-vector/mysterious-mafia-man-smoking-cigarette_52683-34828.jpg?size=338&ext=jpg&ga=GA1.2.1041511529.1663508133";
            }
            var user = new User()
            {

                Name = vm.Name,
                Email = vm.Email,
                Password = vm.Password,
                ProfilePic = vm.ProfilePic

            };

            await userService.AddUser(user);
            return Ok(new {Name= user.Name , Email=user.Email , ProfilePic = user.ProfilePic});
        }


        // Login User
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginInfo loginInfo)
        {
            var user = await userService.Login(loginInfo.Email, loginInfo.Password);
            if (user == null)
                return BadRequest(new { message="Invalid Credentials !"});
            return Ok(user);
        }

    }
}
