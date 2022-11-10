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
    public class UserEFRepository : IRepository<User, string>
    {
       
        private readonly DataBaseContext context;

        /// <summary>
        ///  the constructor calling object to pass in an instance of the context
        /// </summary>
        public UserEFRepository(DataBaseContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// it saves user entity in the users table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>entity to the services</returns>
        public async Task<User> Add(User entity)
        {
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
       
        /// <returns>all the user records from users table</returns>
        public async Task<List<User>> GetAll()
        {
            await Task.CompletedTask;
            return context.Users.ToList();
        }
        
        /// <param name="email"></param>
        /// <returns>user which may be null</returns>
        /// <exception cref="InvalidIdException"></exception>
        public async Task<User> GetByEmail(string email)
        {
            var user = await context.Users.FindAsync(email);

            return user ?? throw new InvalidIdException(email, $"No User found with id : {email}");
        }

        /// <summary>
        /// This method takes user email and fetch user data from users table 
        /// then remove the user record from the users table
        /// </summary>
        /// <param name="email"></param>
        
        public async Task Remove(string email)
        {
            var user = await context.Users.FirstOrDefaultAsync(a => a.Email == email);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

      
        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updating user entity in Users table.
        /// </summary>
        
        public async Task Update(User entity)
        {
            var user = await GetByEmail(entity.Email);
            if (user != null)
            {
                

                await context.SaveChangesAsync();

            }
        }
    }
}
