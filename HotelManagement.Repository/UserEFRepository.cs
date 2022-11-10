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
    public class UserEFRepository : IRepository<User, string>
    {
        private readonly DataBaseContext context;

        public UserEFRepository(DataBaseContext context)
        {
            this.context = context;
        }
        public async Task<User> Add(User entity)
        {
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<User>> GetAll()
        {
            await Task.CompletedTask;
            return context.Users.ToList();
        }

     /*   public async Task<User> GetByEmail(string email)
        {
            var user = await context.Users.FindAsync(email);

            return user ?? throw new InvalidIdException(email, $"No User found with id : {email}");
        }*/

        public async Task<User> GetById(string id)
        {
            var user = await context.Users.FindAsync(id);

            return user ?? throw new InvalidIdException(id, $"No User found with id : {id}");
        }

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

        public async Task Update(User entity)
        {
            var user = await GetById(entity.Email);
            if (user != null)
            {
                

                await context.SaveChangesAsync();

            }
        }
    }
}
