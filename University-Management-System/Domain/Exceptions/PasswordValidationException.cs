namespace University_Management_System.Domain.Exceptions;

public class PasswordValidationException : ValidationException
{
    public PasswordValidationException()
    {

    }

    public PasswordValidationException(string message) : base(message)
    {

    }
}