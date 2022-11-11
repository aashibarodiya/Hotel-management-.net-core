using Castle.Core.Logging;
using HotelManagement.Models;
using HotelManagement.Repository;
using HotelManagement.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services.UserService
{
    public class UserServiceV1 : IUserService
    {
        // Declaring instance of IRepository for user. 
        private readonly IRepository<User, string> repository;
        // Declaring instane of ILogger.
        private readonly ILogger<UserServiceV1> logger;

        /// <summary>
        /// The constructor for UserService with dependency injection of repository, logger
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        public UserServiceV1(IRepository<User, string> repository, ILogger<UserServiceV1> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// The method AddUser passes user entity to the repository
        /// </summary>
        /// <param name="user"></param>
        /// <returns>user</returns>
        public async Task<User> AddUser(User user)
        {
            logger.LogInformation("AddUser called in User Service");
            await repository.Add(user);
            logger.LogInformation("Returning user from User Service");
            return user;
        }

        /// <summary>
        /// The method AddUser passes user entity to the repository
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public async Task DeleteUser(string email)
        {
            logger.LogInformation("DeleteUser called in User Service");
            await repository.Remove(email);
            logger.LogInformation("DeleteUser method ended in User Service");
        }

        /// <summary>
        /// The method GetUserByEmail gets the user data from repository
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException">If email is not correct</exception>

        public async Task<User> GetUserByEmail(string email)
        {
            logger.LogInformation("GetUserByEmail called in User Service");
            var user = await repository.GetById(email);
            if (user != null)
                return user;
            else
            {
                logger.LogError("User trying with Invalid Id");
                throw new InvalidIdException(email);
            }
         
        }
        /// <summary>
        /// The method login fetch user data from repository and checks the parameters passed
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>user</returns>
        /// <exception cref="Exception">If password is incorrect</exception>
        public async Task<User> Login(string email, string password)
        {
            logger.LogInformation("Login called in User Service");
            var user = await repository.GetById(email);
            if (user == null)
                return null;
            if (user.Password == password && user.Email == email)
            {
                return new User()
                {
                    Email = user.Email,
                    Name = user.Name,
                    ProfilePic = user.ProfilePic
                };
            }
            else
            {
                logger.LogError("Invalid Credentials exception thrown");
                throw new Exception(email);

            }

        }

        public async Task UpdateUser(User user)
        {
            await Task.CompletedTask;
        }
    }
}
