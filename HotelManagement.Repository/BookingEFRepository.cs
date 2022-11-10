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
    public class BookingEFRepository : IRepository<Booking, string>
    {
        private readonly DataBaseContext context;

        public BookingEFRepository(DataBaseContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Booking> Add(Booking entity)
        {
            await context.Bookings.AddAsync(entity);
            return entity;
        }

        public async Task<List<Booking>> GetAll()
        {
            await Task.CompletedTask;
            return context.Bookings.ToList();
        }

        public async Task<Booking> GetByEmail(string email)
        {
            var booking = await context.Bookings.FirstOrDefaultAsync(b => b.UserId == email);
            return booking ?? throw new InvalidIdException(email);
        }

        public async Task Remove(string id)
        {
            var booking = await GetByEmail(id);
            if(booking != null)
            {
                context.Bookings.Remove(booking);
                await context.SaveChangesAsync();
            }
        }

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
