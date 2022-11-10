namespace HotelManagement.Utils
{
    // custom exception extends exceptions base class
    public class InvalidIdException : Exception
    {
        public Object Id { get; set; }

        //it intializes a new instance of exception class
        public InvalidIdException(object id, string message = "Invalid Id") : base(message)
        {
            Id = id;
        }
    }
}