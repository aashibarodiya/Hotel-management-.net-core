using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repository
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }


       public DbSet<User> Users { get; set; } 

        public DbSet<Booking> Bookings { get; set; }

    }
}