using Castle.Core.Logging;
using HotelManagement.Models;
using HotelManagement.Repository;
using HotelManagement.Services.UserService;
using HotelManagement.Tests.MockData;
using HotelManagement.Utils;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Tests.Services
{
    // The class contains the test methods of user service.
    public class UserServiceTests
    {
        private UserServiceV1 sut;
        private Mock<IRepository<User, string>> userRepository;
        private ILogger<UserServiceV1> logger;
        // The constructor initializes the mock instance of user repository and logger
        public UserServiceTests()
        {
            userRepository = new Mock<IRepository<User, string>>();
            logger = Mock.Of<ILogger<UserServiceV1>>();
        }
        /// <summary>
        /// The below test method tests the GetAllUsers method of user service  with the mock user repository
        /// and asserts the count of result
        /// </summary>

        [Fact]
        public async Task GetAllUsers_ReturnsListOfUsers()
        {
            // Arrange

            userRepository.Setup(user => user.GetAll()).ReturnsAsync(UsersMockData.GetAllUsers());
            sut = new UserServiceV1(userRepository.Object, logger);
            // Act
            var result = sut.GetAllUsers().Result;
            // Assert
            Assert.Equal(UsersMockData.GetAllUsers().Count, result.Count);

        }
        /// <summary>
        /// The below test method tests the AddUser method of user service with the mock user repository
        /// and asserts the mail from result
        /// </summary>
        [Fact]
        public async Task AddUser_AddsUserToUserRepository()
        {
            // Arrange
            var user = UsersMockData.GetAllUsers().First();
            userRepository.Setup(u => u.Add(user)).ReturnsAsync(user);
            sut = new UserServiceV1(userRepository.Object, logger);
            // Act
            var result = sut.AddUser(user).Result;
            // Assert
            Assert.Equal(user.Email, result.Email);
        }
        /// <summary>
        /// The below test method tests the GetUserByEmail method of user service with the mock user repository
        /// and asserts the email value
        /// </summary>
        [Fact]
        public async Task GetUserByEmail_GetsUserFromRepository()
        {
            // Arrange
            var user = UsersMockData.GetAllUsers().First();
            userRepository.Setup(u => u.GetById(user.Email)).ReturnsAsync(user);
            sut = new UserServiceV1(userRepository.Object, logger);
            // Act
            var result = sut.GetUserByEmail(user.Email).Result;
            // Assert
            Assert.Equal(user.Email, result.Email);
        }
        /// <summary>
        /// The below test method tests the GetUserByEmail method of user service with the mock user repository
        /// for throwing exception
        /// </summary>
        [Fact]
        public async Task GetUserByEmail_ThrowsExceptionForInvalidEmail()
        {
            // Arrange
            var user = UsersMockData.GetAllUsers().First();
            userRepository.Setup(u => u.GetById(user.Email + "aa")).ReturnsAsync(user);
            // Assert
            Assert.ThrowsAsync<InvalidIdException>(async () =>
            {
                // Act
                var result = sut.GetUserByEmail(user.Email + "aa").Result;

            });
        }
    }
}