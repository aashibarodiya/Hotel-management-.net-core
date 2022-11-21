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
    // The class contains the test methods of booking repository
    public class BookingEFRepositoryTest : IDisposable
    {
        private DataBaseContext _context;
        private readonly BookingEFRepository sut;
        // The constructor initializes the mock instance of logger,
        // set the DbContext options which creates the in memory database based on the DBContext
        // and initializing system under test object. 
        public BookingEFRepositoryTest()
        {
            var logger = Mock.Of<ILogger<BookingEFRepository>>();
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new DataBaseContext(options);
            _context.Database.EnsureCreated();
            _context.Bookings.AddRange(BookingsMockData.GetBookings());
            _context.SaveChanges();
            sut = new BookingEFRepository(_context, logger);
        }
        /// <summary>
        /// The below test method tests the Add method of BookingEFRepository
        /// with in memory database and checking the result
        /// </summary>
        [Fact]
        public async Task Add_AddsBookings()
        {
            //Arrange
            var booking = BookingsMockData.GetBooking();
            //Act
            await sut.Add(booking);
            var result = await sut.GetAll();
            //Assert
            result.Should().HaveCount(BookingsMockData.GetBookings().Count() + 1);


        }
        /// <summary>
        /// The below test method tests the GetAll method of BookingEFRepository
        /// with in memory database and checking the returned count
        /// </summary>
        [Fact]
        public async Task GetAll_ReturnsAllBookings()
        {
            //Arrange
            var bookings = BookingsMockData.GetBookings();
            //Act
            var result = await sut.GetAll();
            //Assert
            result.Should().HaveCount(bookings.Count());
        }
        /// <summary>
        /// The below test method tests the GetById method of BookingEFRepository
        ///  with in memory database and checking the returned booking id
        /// </summary>
        [Fact]
        public async Task GetById_ReturnsBooking()
        {
            //Arrange
            var booking = BookingsMockData.GetBookings().First();

            //Act
            var result = await sut.GetById(booking.Id);

            //Assert
            result.Id.Should().Be(booking.Id);

        }
        /// <summary>
        /// The below test method tests the GetById method of BookingEFRepository 
        /// for invalid booking id scenario
        /// with in memory database and checking the exception
        /// </summary>
        [Fact]
        public async Task GetById_ThrowsExceptionForInvalidId()
        {
            //Arrange
            //var booking=BookingsMockData.GetBookings().First();
            //Act
            //var result = await sut.GetById(5);

            //Assert

            await Assert.ThrowsAsync<InvalidIdException>(async () => await sut.GetById(5));
        }
        /// <summary>
        /// The below test method tests the Remove method of BookingEFRepository 
        /// for invalid booking id scenario
        /// with in memory database and checking the exception
        /// </summary>
        [Fact]
        public async Task Remove_RemovesTheBooking()
        {
            //Arrange
            var booking = BookingsMockData.GetBookings().First();

            //Act
            await sut.Remove(booking.Id);

            //Assert
            await Assert.ThrowsAsync<InvalidIdException>(async () => await sut.GetById(booking.Id));
        }
        /// <summary>
        /// The below test method tests the update method of BookingEFRepository 
        /// with in memory database and checking the updated price
        /// </summary>
        [Fact]
        public async Task Update_UpdatesTheBooking()
        {
            //Arrange
            var booking = BookingsMockData.GetBookings().First();
            booking.Price = 1000;

            //Act
            await sut.Update(booking);
            var result = await sut.GetById(booking.Id);

            //Assert
            result.Price.Should().Be(booking.Price);

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
