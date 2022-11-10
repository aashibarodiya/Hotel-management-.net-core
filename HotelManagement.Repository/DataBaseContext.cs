using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repository
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }


        public DbSet<User> Users { get; set; } 

        public DbSet<Booking> Bookings { get; set; }

    }
}