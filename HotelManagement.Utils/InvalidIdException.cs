namespace HotelManagement.Utils
{
    // Custom exception extends exceptions base class
    public class InvalidIdException : Exception
    {
        public Object Id { get; set; }

        // It intializes a new instance of exception class
        public InvalidIdException(object id, string message = "Invalid Id") : base(message)
        {
            id=id;
        }
    }
}