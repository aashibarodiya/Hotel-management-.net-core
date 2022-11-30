using HotelManagement.Models;
using HotelManagement.Repository;
using HotelManagement.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services.BookingService
{
    public  class BookingServiceV1  : IBookingService
    {
        private IRepository<Booking, int> _bookingRepository;
        private readonly ILogger<BookingServiceV1> logger;



        // Constructor with repository dependency injection



        public BookingServiceV1(IRepository<Booking, int> bookingRepository , ILogger<BookingServiceV1> logger)

        {
            _bookingRepository = bookingRepository;
            this.logger = logger;
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



        public async Task DeleteBooking(int id)
        {
            await _bookingRepository.Remove(id);
        }

        public async Task<List<Booking>> GetAllBookings()
        {
           var bookings=  await _bookingRepository.GetAll();

            return bookings;

        }

        public async Task<Booking> GetBooking(int id)
        {
            var booking = await _bookingRepository.GetById(id);
            return booking ?? throw new InvalidIdException(id);
        }



        public async Task UpdateBooking(Booking booking)
        {
            await _bookingRepository.Update(booking);
        }
    }
}
