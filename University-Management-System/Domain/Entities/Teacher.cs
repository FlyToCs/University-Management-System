
using University_Management_System.Domain.Enums;

namespace University_Management_System.Domain.Entities;

public class Teacher(int id, 
    string firstName, 
    string lastName, 
    string username,
    string password, 
    string email, 
    RoleEnum role) : User(id, firstName, lastName, username, password, email, role)
{
    public override void EnsurePassword(string password)
    {
        if (password.Length < 6)
            throw new AbandonedMutexException("Password should contain at least 6 characters");
        
    }
}

