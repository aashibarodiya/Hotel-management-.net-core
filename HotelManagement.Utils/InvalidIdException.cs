namespace HotelManagement.Utils
{
    public class InvalidIdException : Exception
    {
        public Object Id { get; set; }

        public InvalidIdException(object id, string message = "Invalid Id") : base(message)
        {
            Id = id;
        }
    }
}