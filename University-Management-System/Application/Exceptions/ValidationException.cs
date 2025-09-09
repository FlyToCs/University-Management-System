namespace University_Management_System.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
    {
        
    }

    public ValidationException(string message) : base(message)
    {
        
    }
}