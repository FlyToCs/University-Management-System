using System.Reflection.Metadata;

namespace University_Management_System.Domain.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
    {
        
    }

    public ValidationException(string message) : base(message)
    {
        
    }
    
}