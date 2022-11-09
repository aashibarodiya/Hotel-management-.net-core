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

        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Booking booking)
        {

           

            return Ok(booking);
        }
    }
}
