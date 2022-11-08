using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    
    
        public enum RoomTypes { Deluxe, SemiDeluxe, SuperDeluxe }
        public class RoomType
        {
            public int Id { get; set; }
            public RoomTypes Name { get; set; }
            public string PhotoUrl { get; set; }
        }
    
}
