using HotelManagement.Models;
using HotelManagement.Repository;
using HotelManagement.Services.BookingService;
using HotelManagement.Tests.MockData;
using HotelManagement.Utils;
using Microsoft.Extensions.Logging;
using Moq;

namespace HotelManagement.Tests.Services
{
    // The class contains the test methods of user service.
    public class BookingServiceTests
    {
        private BookingServiceV1 sut;
        private Mock<IRepository<Booking, int>> bookingRepository;
        private ILogger<BookingServiceV1> logger;
        // The constructor initializes the mock of booking repository and logger
        public BookingServiceTests()
        {
            bookingRepository = new Mock<IRepository<Booking, int>>();
            logger = Mock.Of<ILogger<BookingServiceV1>>();
        }
        /// <summary>
        /// The below test method tests the getbookings method of booking service 
        /// by mocking the booking repository
        /// </summary>
        [Fact]
        public async Task GetAllBookings_ReturnAllBookings()
        {
            // Arrange
            bookingRepository = new Mock<IRepository<Booking, int>>();
            bookingRepository.Setup(b => b.GetAll())
                    .Returns(Task.FromResult(BookingsMockData.GetBookings()));
            sut = new BookingServiceV1(bookingRepository.Object, logger);


            // Act
            var result = sut.GetAllBookings().Result;

            // Assert
            Assert.Equal(BookingsMockData.GetBookings().Count, result.Count);
        }
        /// <summary>
        /// The below test method tests the getbooking method of booking service 
        /// by mocking the booking repository
        /// </summary>
        [Fact]
        public async Task GetBooking_ReturnsBookingForValidBookingId()
        {
            // Arrange
            bookingRepository = new Mock<IRepository<Booking, int>>();
            bookingRepository.Setup(b => b.GetById(1))
                    .Returns(Task.FromResult(BookingsMockData.GetBooking(1)));
            sut = new BookingServiceV1(bookingRepository.Object, logger);

            var expected = BookingsMockData.GetBooking(1);
            // Act
            var result = sut.GetBooking(1);

            // Assert
            Assert.NotNull(result);
        }
        /// <summary>
        /// The below test method tests the getbooking method of booking service for invalid booking id
        /// by mocking the booking repository
        /// </summary>
        [Fact]
        public async Task GetBooking_ThrowsInvalidIdExceptionForInvalidBookingId()
        {
            // Arrange
            bookingRepository = new Mock<IRepository<Booking, int>>();
            bookingRepository.Setup(b => b.GetById(-1))
                    .Returns(Task.FromResult(BookingsMockData.GetBooking(-1)));
            sut = new BookingServiceV1(bookingRepository.Object, logger);

            var expected = BookingsMockData.GetBooking(-1);


            // Assert
            Assert.ThrowsAsync<InvalidIdException>(async () =>
            {
                // Act
                var result = sut.GetBooking(-1);
            });
        }
        /// <summary>
        /// The below test method tests the add booking method of booking service 
        /// by mocking the booking repository
        /// </summary>
        [Fact]
        public async Task AddBooking_AddsBookingInRepository()
        {
            // Arrange
            bookingRepository = new Mock<IRepository<Booking, int>>();
            var booking = BookingsMockData.GetBooking(1);
            bookingRepository.Setup(b => b.Add(booking))
                    .Returns(Task.FromResult(BookingsMockData.GetBooking(1)));
            var sut = new BookingServiceV1(bookingRepository.Object, logger);

            var expected = BookingsMockData.GetBooking(1);
            // Act
            var result = sut.GetBooking(1);

            // Assert
            Assert.NotNull(result);
        }
        /// <summary>
        /// The below test method tests the delete booking method of booking service 
        /// by mocking the booking repository
        /// </summary>
        [Fact]
        public async Task DeleteBooking_DeleteBookingFromRepository()
        {
            // Arrange
            bookingRepository = new Mock<IRepository<Booking, int>>();
            var booking = BookingsMockData.GetBooking(1);
            bookingRepository.Setup(b => b.Remove(booking.Id)).Equals(1);

            var sut = new BookingServiceV1(bookingRepository.Object, logger);


            // Act
            var result = sut.DeleteBooking(booking.Id);

            // Assert
            Assert.NotNull(result);
        }




    }
}