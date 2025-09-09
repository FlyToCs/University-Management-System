namespace University_Management_System.Application.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException()
    {
        
    }
    public UserNotFoundException(string message):base(message)
    {
        
    }
}