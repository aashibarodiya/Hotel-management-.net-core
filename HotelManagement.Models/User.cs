using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    // Class UserInfo with the following properties except password.
    public class UserInfo
    {
        public string Name { get; set; }

        [Key]
        public string Email { get; set; }
        public string ProfilePic { get; set; }

        public string PhoneNumber { get; set; }
        public string AadhaarId { get; set; }

        // It allows the lazy lading
        // to get the data from reference table
        public virtual List<Booking> UserBookings { get; set; }


    }
    // Class user extending userInfo class with password property.
    public class User : UserInfo
    {
        public string Password { get; set; }
    }

}