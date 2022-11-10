using HotelManagement.Models;
using HotelManagement.Services.BookingService;
using Microsoft.AspNetCore.Mvc;
using System.Resources;
using HotelManagement.Utils;
using HotelManagement.API.ViewModel;

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

     


        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var result = await bookingService.GetAllBookings();

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookingVm vm)
        {

            await bookingService.AddBooking(booking);
            return Ok(booking);

            var Bookings= await bookingService.GetAllBookings();
            var totalBookings= Bookings.Count;

            var totalRooms = RoomDetails.ResourceManager.GetString("TotalRooms");
            var price =Convert.ToInt32(RoomDetails.ResourceManager.GetString("Price"));


            if (totalBookings < Convert.ToInt32(totalRooms))
            {
                var booking = new Booking()
                {
                    UserId = vm.UserId,
                    NumberOfDaysStay = vm.NumberOfDaysStay,
                    RoomNo = totalBookings + 1,
                    Price = vm.NumberOfDaysStay * price
                    
                 };

                await bookingService.AddBooking(booking);
                return Ok(booking);
            }

            return BadRequest();

        }


        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            await bookingService.DeleteBooking(bookingId);
            return NoContent();
        }



        [HttpPut("{bookingId}")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingVm vm, int bookingId)
        {
            var book = await bookingService.GetBooking(bookingId);
            var booking = new Booking()
            {   Id = bookingId,
                UserId = vm.UserId,
                NumberOfDaysStay = vm.NumberOfDaysStay,
                RoomNo = book.RoomNo,
                Price = vm.NumberOfDaysStay * (Convert.ToInt32(RoomDetails.ResourceManager.GetString("Price")))
            };

            await bookingService.UpdateBooking(booking);

            return Accepted(booking);

        }

    }
}
