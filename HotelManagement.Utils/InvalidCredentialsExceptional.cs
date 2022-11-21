using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Utils
{
    public class InvalidCredentialsException : Exception
    {
        public Object Password { get; set; }
        // It intializes a new instance of exception class
        public InvalidCredentialsException(object password, string message = "Invalid Password") : base(message)
        {
            Password = password;
        }
    }
}
