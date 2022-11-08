using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public int NumberOfDaysStay { get; set; }
        public int Price { get; set; }

        //virtual allows the Entity Framework to use lazy loading
        public virtual RoomTypes RoomType { get; set; }

    }
}
