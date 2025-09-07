
using University_Management_System.Domain.Enums;

namespace University_Management_System.Domain.Entities;

internal class Teacher(int id, 
    string firstName, 
    string lastName, 
    string username,
    string password, 
    string email, 
    RollEnum roll) : User(id, firstName, lastName, username, password, email, roll)
{
    public override void EnsurePassword(string password)
    {
        if (password.Length < 6)
            throw new AbandonedMutexException("Password should contain at least 6 characters");
        
    }
}

