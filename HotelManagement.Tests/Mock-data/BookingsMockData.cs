using HotelManagement.API.ViewModel;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Tests.MockData
{
    public class BookingsMockData
    {
        public static List<Booking> GetBookings()
        {
            return new List<Booking>
            {
                new Booking
                {
                    Id = 1,
                    UserId = "aashi@gmail.com",

                    NumberOfDaysStay = 1,
                    Price = 500,
                    BookingDate = DateTime.Today
                },
                new Booking {
                    Id = 2,
                    UserId = "parth@gmail.com",
                    NumberOfDaysStay = 3,
                    Price = 1500,
                    BookingDate = DateTime.Today

                },
                new Booking {
                    Id = 3,
                    UserId = "nidhi@gmail.com",
                    NumberOfDaysStay = 2,
                    Price = 1000,
                    BookingDate = DateTime.Today

                }


        };
        }

        public static List<BookingVm> GetBookingVms()
        {
            return new List<BookingVm>
            {
                new BookingVm
                {
                    UserId = "aashi@gmail.com",
                    NumberOfDaysStay = 1

                },
                new BookingVm {
                    UserId = "parth@gmail.com",
                    NumberOfDaysStay = 3

                },
                new BookingVm {
                    UserId = "nidhi@gmail.com",
                    NumberOfDaysStay = 2

                }


        };
        }

        public static List<Booking> GetEmptyBookings()
        {
            return new List<Booking>();
        }
        public static Booking GetBooking(int id)
        {
            return new Booking
            {
                Id = 1,
                UserId = "aashi@gmail.com",
                NumberOfDaysStay = 1,
                Price = 500,
                BookingDate = DateTime.Today
            };
        }
        public static Booking GetBooking()
        {
            return new Booking
            {
                Id = 4,
                UserId = "disha@gmail.com",
                NumberOfDaysStay = 2,
                Price = 1000,
                BookingDate = DateTime.Today
            };
        }
        public static int DeleteBooking(int id)
        {
            return 1;
        }
    }
}