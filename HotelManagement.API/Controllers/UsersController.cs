using HotelManagement.API.ViewModel;
using HotelManagement.Models;
using HotelManagement.Services.UserService;
using HotelManagement.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Services.WebApi.Jwt;
using Polly;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace HotelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        // Declaring user service
        private readonly IUserService userService;
        // Declaring instance of ILogger.
        private readonly ILogger<UsersController> logger;
        // Declaring instance of configuration. 
        IConfiguration configuration;
        private object _configuration;

        // Constructor for UsersController with dependency injection of userService, configuration and logger
        public UsersController(IUserService userService, 
            IConfiguration configuration,
            ILogger<UsersController> logger
           )
        {
            this.userService = userService;
            this.configuration = configuration;
            this.logger = logger;
        
        }


        /// <summary>
        /// API Register method takes user properties and add user to the users table
        /// </summary>
        /// <param name="vm"></param>
        /// <returns>user</returns>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserViewModel vm)
        {
            logger.LogInformation("Registering a new user");
            if (string.IsNullOrEmpty(vm.ProfilePic))
            {
                vm.ProfilePic = "https://img.freepik.com/free-vector/mysterious-mafia-man-smoking-cigarette_52683-34828.jpg?size=338&ext=jpg&ga=GA1.2.1041511529.1663508133";
                logger.LogWarning("As profile picture is not passed by user, default profile picture is used");
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
            logger.LogInformation("Registration completed");
            return Ok(new {Name= user.Name , Email=user.Email , ProfilePic = user.ProfilePic});
            
        }


        /// <summary>
        /// API Login method takes login info and invoking login method in user service
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns>user</returns>
        /// 
        [HttpPost("login")]
        [ExceptionMapper(ExceptionType = typeof(InvalidIdException), StatusCode = 401,Message ="No such user exists")]
        public async Task<IActionResult> Login([FromBody] LoginInfo loginInfo)
        {
            logger.LogInformation("User trying to login");
            var user = await userService.Login(loginInfo.Email, loginInfo.Password);

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Email", user.Email),
                    
           };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            Console.WriteLine("ok");
            Console.WriteLine(tokenString);
            logger.LogInformation("User logged in");
            return Ok(new
            {
                token = tokenString,
                user = user

            });
           
           
        }

        /// <summary>
        /// API getUser method takes user email and get user details from user service
        /// </summary>
        /// <param name="email"></param>
        /// <returns>user</returns>
        [HttpGet("{email}")]
        public async Task<IActionResult> getUser(string email)
        {
            logger.LogInformation("Getting user details");
            var user = await userService.GetUserByEmail(email);

            return Ok(user);
        }
    }
}
