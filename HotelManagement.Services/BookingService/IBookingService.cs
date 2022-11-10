using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services.BookingService
{
    // Interface IBookingService containing method declartions related to Room Bookings.
    public interface IBookingService
    {
        //this represents crud operations which return a value
        public Task<Booking> AddBooking(Booking booking);

        public Task DeleteBooking(int id);

        public Task UpdateBooking(Booking booking);

        public Task<Booking> GetBooking(int id);

        public Task<List<Booking>> GetAllBookings();
    }
}
