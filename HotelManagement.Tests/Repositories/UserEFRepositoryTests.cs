using FluentAssertions;
using HotelManagement.Repository;
using HotelManagement.Tests.MockData;
using HotelManagement.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Tests.Repositories
{
    // The class contains the test methods of user repository
    public class UserEFRepositoryTests : IDisposable
    {
        private DataBaseContext _context;
        private readonly UserEFRepository sut;

        // The constructor initializes the mock instance of logger,
        // set the DbContext options which creates the in memory database based on the DBContext
        // and initializing system under test object. 
        public UserEFRepositoryTests()
        {
            var logger = Mock.Of<ILogger<UserEFRepository>>();
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataBaseContext(options);
            _context.Database.EnsureCreated();
            _context.Users.AddRange(UsersMockData.GetAllUsers());
            _context.SaveChanges();
            sut = new UserEFRepository(_context, logger);
        }
        /// <summary>
        /// The below test method tests the Add method of UserEFRepository
        /// with in memory database and checking the returned count
        /// </summary>
        [Fact]
        public async Task Add_AddstheUser()
        {
            var user = UsersMockData.GetUser();
            await sut.Add(user);
            var result = await sut.GetAll();
            result.Should().HaveCount(UsersMockData.GetAllUsers().Count + 1);

        }
        /// <summary>
        /// The below test method tests the GetAll method of UserEFRepository
        /// with in memory database and checking the returned count
        /// </summary>

        [Fact]
        public async Task GetAll_ReturnsAllUsers()
        {
            var results = await sut.GetAll();
            results.Should().HaveCount(UsersMockData.GetAllUsers().Count);
        }
        /// <summary>
        /// The below test method tests the GetAll method of UserEFRepository
        ///  with in memory database and checking the returned count for empty data scenario
        /// </summary>
        [Fact]
        public async Task GetAll_ReturnsEmptyForEmptyUsers()
        {
            _context.Database.EnsureDeleted();
            var result = await sut.GetAll();
            result.Should().HaveCount(UsersMockData.GetEmptyUsers().Count);
        }

        /// <summary>
        /// The below test method tests the GetById method of UserEFRepository
        ///  with in memory database and checking the returned email value
        /// </summary>

        [Fact]
        public async Task GetById_ReturnsValidUser()
        {
            var user = UsersMockData.GetAllUsers().First();
            var result = await sut.GetById(user.Email);
            result.Email.Should().BeSameAs(user.Email);
        }
        /// <summary>
        /// The below test method tests the GetById method of UserEFRepository for invalid mail scenario
        ///  with in memory database and checking the exception
        /// </summary>
        [Fact]
        public async Task GetById_ThrowsExceptionForInvalidMail()
        {
            var user = UsersMockData.GetAllUsers().First();

            Assert.ThrowsAsync<InvalidIdException>(async () =>
            {
                var result = await sut.GetById(user.Email + "aa");

            });
        }
        /// <summary>
        /// Destroy the in-memory database so that every test case will have its own in-memory database.
        /// </summary>
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}