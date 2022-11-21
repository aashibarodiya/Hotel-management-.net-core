using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repository
{
    /// <summary>
    /// DbContext is a bridge between our domain or entity classes and the database
    /// it saves instances to our entities
    /// </summary>
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


       // public DbSet<User> Users { get; set; } 

        public DbSet<Booking> Bookings { get; set; }

    }
}