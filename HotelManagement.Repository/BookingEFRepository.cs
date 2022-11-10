using HotelManagement.Models;
using HotelManagement.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace HotelManagement.Repository
{

    /// <summary>
    /// creating repository which makes an abstraction 
    /// layer between the data access layer and the business 
    /// logic layer of an application.
    /// </summary>
    public class BookingEFRepository : IRepository<Booking, string>

    public class BookingEFRepository : IRepository<Booking, int>

    {
        private readonly DataBaseContext context;

        /// <summary>
        /// the constructor calling object to pass in an instance of the context
        /// as dependency injection
        /// </summary>
        /// <param name="context"></param>
        public BookingEFRepository(DataBaseContext context)
        {
            this.context = context;
        }

        
        /// <param name="entity"></param>
        /// <returns>it saves the entity in the services</returns>
        public async Task<Booking> Add(Booking entity)
        {
            await context.Bookings.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        /// <returns>list of bookings</returns>
        public async Task<List<Booking>> GetAll()
        {
            await Task.CompletedTask;
            return context.Bookings.ToList();
        }


        
        /// <param name="email">it saves email in the service and determine</param>
        /// <returns>booking info</returns>
        /// <exception cref="InvalidIdException">if the booking is not in the bookings table 
        /// exception will be thrown</exception>
        public async Task<Booking> GetByEmail(string email)

        public async Task<Booking> GetById(int id)

        {
            var booking = await context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            return booking ?? throw new InvalidIdException(id);
        }


        
        /// <returns>it contains no of entries written to the database</returns>
        public async Task Remove(string id)

        public async Task Remove(int id)

        {
            var booking = await GetById(id);
            if(booking != null)
            {
                context.Bookings.Remove(booking);
                await context.SaveChangesAsync();
            }
        }

       
        /// <returns>Price</returns>
        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public async Task Update(Booking entity)
        {
            var oldBooking = await context.Bookings.FirstOrDefaultAsync(b => b.Id == entity.Id);

             oldBooking.NumberOfDaysStay = entity.NumberOfDaysStay;
             oldBooking.Price = entity.Price;

            await Save();

        }
    }
}
