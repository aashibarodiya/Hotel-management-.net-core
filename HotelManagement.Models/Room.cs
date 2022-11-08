using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Room
    {
        //Room Ids limited upto 9 starting from 1 
        public int Id { get; set; }

        //virtual allows the Entity Framework to use lazy loading
        public virtual RoomType RoomType { get; set; }

        [Range(0, 5000)]
        public int Price { get; set; }

        [Range(1, 5)]
        public double Rating { get; set; }

    }
}
