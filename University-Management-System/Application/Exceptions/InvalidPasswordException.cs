namespace University_Management_System.Application.Exceptions;

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException()
    {
        
    }

    public InvalidPasswordException(string massage) : base(massage)
    {
        
    }
}