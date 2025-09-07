using University_Management_System.Domain.Enums;

namespace University_Management_System.Domain.Entities;

public class Operator(int id, string firstName, string lastName, string username, string password, string email, RollEnum roll) : User(id, firstName, lastName, username, password, email, roll)
{
    
}