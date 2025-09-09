namespace University_Management_System.Application.Exceptions;

public class InvalidEmailException : ValidationException
{
    public InvalidEmailException()
    {
        
    }

    public InvalidEmailException(string message) : base(message)
    {
        
    }
}