using HotelManagement.API.ViewModel;
using HotelManagement.Models;
using HotelManagement.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // Declaring user service
        private readonly IUserService userService;

        // Constructor for UsersController with dependency injection of userService
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        /// <summary>
        /// API Register method takes user properties and add user to the users table
        /// </summary>
        /// <param name="vm"></param>
        /// <returns>user</returns>
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
                ProfilePic = vm.ProfilePic,
                PhoneNumber = vm.PhoneNumber,
                AadhaarId = vm.AadhaarId
                

            };

            await userService.AddUser(user);
            return Ok(new {Name= user.Name , Email=user.Email , ProfilePic = user.ProfilePic});
        }


        /// <summary>
        /// API Login method takes login info and invoking login method in user service
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns>user</returns>
        /// 
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginInfo loginInfo)
        {
            var user = await userService.Login(loginInfo.Email, loginInfo.Password);
            if (user == null)
                return BadRequest(new { message="Invalid Credentials !"});
            return Ok(user);
        }

        /// <summary>
        /// API getUser method takes user email and get user details from user service
        /// </summary>
        /// <param name="email"></param>
        /// <returns>user</returns>
        [HttpGet("{email}")]
        public async Task<IActionResult> getUser(string email)
        { 
            var user = await userService.GetUserByEmail(email);

            return Ok(user);
        }
    }
}
