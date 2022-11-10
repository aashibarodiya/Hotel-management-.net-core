using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
   // Booking class includes the following properties.
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RoomNo { get; set; }
        public int NumberOfDaysStay { get; set; }
        public int Price { get; set; }


    }
}
