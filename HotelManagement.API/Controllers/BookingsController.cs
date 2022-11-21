using HotelManagement.Models;
using HotelManagement.Services.BookingService;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Utils;
using HotelManagement.API.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService bookingService;
        // Declaring instance of ILogger.
        private readonly ILogger<BookingsController> logger;
        // Declaring instance of configuration.
        IConfiguration configuration;

        // Constructor for BookingsController with dependency injection of bookingService.
        public BookingsController(IBookingService bookingService, IConfiguration configuration,
            ILogger<BookingsController> logger)
        {
            this.bookingService = bookingService;
            this.configuration = configuration;
            this.logger = logger;
        }


        /// <summary>
        /// API Create method takes booking instance and add the data to booking table
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>booking object</returns>




        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var result = await bookingService.GetAllBookings();
            if (result.Count == 0)
                return NoContent();
            return Ok(result);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] BookingVm vm)
        {
            logger.LogInformation("Creating a booking of user");
            var Bookings = await bookingService.GetAllBookings();
            var totalBookings = Bookings!.Count;

            var totalRooms = RoomDetails.ResourceManager.GetString("TotalRooms");
            var price = Convert.ToInt32(RoomDetails.ResourceManager.GetString("Price"));


            if (totalBookings < Convert.ToInt32(totalRooms))
            {
                var booking = new Booking()
                {
                    UserId = vm.UserId,
                    NumberOfDaysStay = vm.NumberOfDaysStay,
                    Price = vm.NumberOfDaysStay * price,
                    BookingDate = DateTime.Today

                };

                await bookingService.AddBooking(booking);
                logger.LogInformation("User booking details is created");
                return Created("", booking);
            }


            return BadRequest();

        }


        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            logger.LogInformation("Delete of booking");
            await bookingService.DeleteBooking(bookingId);
            logger.LogInformation("Room booked by user is deleted");
            return NoContent();
        }



        [HttpPut("{bookingId}")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingVm vm, int bookingId)
        {
            logger.LogInformation("update of room booking");
            var book = await bookingService.GetBooking(bookingId);
            if (book == null)
                return BadRequest();
            var booking = new Booking()
            {
                Id = bookingId,
                UserId = vm.UserId,
                NumberOfDaysStay = vm.NumberOfDaysStay,
                Price = vm.NumberOfDaysStay * (Convert.ToInt32(RoomDetails.ResourceManager.GetString("Price")))
            };

            await bookingService.UpdateBooking(booking);
            logger.LogInformation("room booking updated by user");
            return Accepted(booking);

        }

    }
}