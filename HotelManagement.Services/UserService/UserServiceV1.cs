using HotelManagement.Models;
using HotelManagement.Repository;
using HotelManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services.UserService
{
    public class UserServiceV1 : IUserService
    {
        private readonly IRepository<User, string> repository;

        public UserServiceV1(IRepository<User, string> repository)
        {
            this.repository = repository;
        }
        public async Task<User> AddUser(User user)
        {
            await repository.Add(user);
            return user;
        }

        public async Task DeleteUser(string email)
        {
            await repository.Remove(email);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await repository.GetByEmail(email);
            return user ?? throw new InvalidIdException(email);
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await repository.GetByEmail(email);
            if (user == null)
                return null;
            if (user.Password == password && user.Email == email)
            {
                return new User()
                {
                    Email = user.Email,
                    Name = user.Name,
                    ProfilePic = user.ProfilePic
                };
            }

            throw new Exception("Invalid Credentials");

        }

        public async Task UpdateUser(User user)
        {
            await Task.CompletedTask;
        }
    }
}
