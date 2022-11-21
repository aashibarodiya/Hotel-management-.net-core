using HotelManagement.API.ViewModel;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Tests.MockData
{
    public class UsersMockData
    {
        public static List<User> GetAllUsers()
        {
            return new List<User> {
            new User()
            {
                Name = "Aashi",
                Email = "aashi@gmail.com",
                Password="1234",
                ProfilePic = "https://randomuser.me/api/portraits/women/63.jpg",
                PhoneNumber = "9064371293",
                AadhaarId = "223141225798",
                UserBookings=new List<Booking>()
            },
            new User()
            {
                Name = "parth",
                Email = "parth@gmail.com",
                Password="1234",
                ProfilePic = "https://randomuser.me/api/portraits/men/14.jpg",
                PhoneNumber = "5633792145",
                AadhaarId = "094812347546",
                UserBookings=new List<Booking>()
            }
            };
        }

        public static List<User> GetEmptyUsers()
        {
            return new List<User>();
        }
        public static List<UserViewModel> GetAllUsersViewModels()
        {
            return new List<UserViewModel> {
            new UserViewModel()
            {
                Name = "Aashi12",
                Email = "aashi12@gmail.com",
                Password="1234",
                ProfilePic = "https://randomuser.me/api/portraits/women/63.jpg",
                PhoneNumber = "9064371293",
                AadhaarId = "223141225798",

            },
            new UserViewModel()
            {
                Name = "Parth jain",
                Email = "parth1@gmail.com",
                Password="1234",
                ProfilePic = "https://randomuser.me/api/portraits/men/14.jpg",
                PhoneNumber = "0933792145",
                AadhaarId = "874812347546",

            }
            };
        }
        public static List<UserInfo> GetAllUsersInfo()
        {
            return new List<UserInfo> {
            new User()
            {
                Name = "Aashi",
                Email = "aashi@gmail.com",
                ProfilePic = "https://randomuser.me/api/portraits/women/63.jpg",
                PhoneNumber = "9064371293",
                AadhaarId = "223141225798"
            },
            new User()
            {
                Name = "Parth jain",
                Email = "parth1@gmail.com",
                ProfilePic = "https://randomuser.me/api/portraits/men/14.jpg",
                PhoneNumber = "0933792145",
                AadhaarId = "874812347546"
            }
            };
        }
        public static User GetUserInfo()
        {
            return new User
            {
                Name = "Parth jain",
                Email = "parth1@gmail.com",
                ProfilePic = "https://randomuser.me/api/portraits/men/14.jpg",
                PhoneNumber = "0933792145",
                AadhaarId = "874812347546"
            };
        }

        public static User Register(User user)
        {
            return new User()
            {
                Name = "Aashi",
                Email = "aashi@gmail.com",
                Password = "1234",
                ProfilePic = "https://randomuser.me/api/portraits/women/63.jpg",
                PhoneNumber = "9064371293",
                AadhaarId = "223141225798",
                UserBookings = new List<Booking>()
            };
        }
        public static User GetUser()
        {
            return new User()
            {
                Name = "nidhi",
                Email = "nidhi@gmail.com",
                Password = "1234",
                ProfilePic = "https://randomuser.me/api/portraits/women/63.jpg",
                PhoneNumber = "76643713293",
                AadhaarId = "63141225798",
                UserBookings = new List<Booking>()
            };
        }
    }
}

