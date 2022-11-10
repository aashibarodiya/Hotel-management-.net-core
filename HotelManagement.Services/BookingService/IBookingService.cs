﻿using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services.BookingService
{
    public interface IBookingService
    {
        public Task<Booking> AddBooking(Booking booking);

        public Task DeleteBooking(int id);

        public Task UpdateBooking(Booking booking);

        public Task<Booking> GetBooking(int id);

        public Task<List<Booking>> GetAllBookings();
    }
}
