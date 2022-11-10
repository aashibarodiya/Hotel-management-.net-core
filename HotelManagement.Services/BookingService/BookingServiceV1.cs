using HotelManagement.Models;
using HotelManagement.Repository;
using HotelManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services.BookingService
{
    public  class BookingServiceV1  : IBookingService
    {
        private IRepository<Booking, string> _bookingRepository;


        // Constructor with repository dependency injection
        public BookingServiceV1(IRepository<Booking, string> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }


        /// <summary>
        /// this calls the repository of add method
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>booking</returns>
        public async Task<Booking> AddBooking(Booking booking)
        {
            await _bookingRepository.Add(booking);
            return booking;
        }



        public async Task DeleteBooking(string id)
        {
            await _bookingRepository.Remove(id);
        }



        public async Task<Booking> GetBooking(string id)
        {
            var booking = await _bookingRepository.GetByEmail(id);
            return booking ?? throw new InvalidIdException(id);
        }



        public async Task UpdateBooking(Booking booking)
        {
            await _bookingRepository.Update(booking);
        }
    }
}
