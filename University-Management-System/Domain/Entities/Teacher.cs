
using University_Management_System.Domain.Enums;
using University_Management_System.Domain.Exceptions;

namespace University_Management_System.Domain.Entities;

public class Teacher(int id,
    int teNumber, 
    string firstName, 
    string lastName, 
    string username,
    string password, 
    string email, 
    RoleEnum role) : User(id, firstName, lastName, username, password, email, role)
{

    public int TeNumber { get; set; } = teNumber;
    public override void EnsurePassword(string password)
    {
        if (password.Length < 6)
            throw new PasswordValidationException("Password should contain at least 6 characters");
        
    }
}

