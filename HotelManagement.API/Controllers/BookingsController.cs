using HotelManagement.Models;
using HotelManagement.Services.BookingService;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService bookingService;

        // Constructor for BookingsController with dependency injection of bookingService.
        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        /// <summary>
        /// API Create method takes booking instance and add the data to booking table
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>booking object</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Booking booking)
        {
            await bookingService.AddBooking(booking);
            return Ok(booking);
        }
    }
}
