namespace HotelManagement.Models
{
    
        public class UserInfo
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string ProfilePic { get; set; }

            public string PhoneNumber { get; set; }
            public string AadhaarId { get; set; }


        }
        public class User : UserInfo
        {
            public string Password { get; set; }
        }
    
}