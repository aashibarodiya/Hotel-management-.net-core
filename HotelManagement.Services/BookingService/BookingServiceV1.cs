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
        private IRepository<Booking, int> _bookingRepository;



        public BookingServiceV1(IRepository<Booking, int> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }



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
