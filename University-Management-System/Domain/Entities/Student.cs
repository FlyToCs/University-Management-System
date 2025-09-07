using University_Management_System.Domain.Enums;

namespace University_Management_System.Domain.Entities;

public class Student(int id, string firstName, string lastName, string username, string password, string email, RollEnum roll) : User(id, firstName, lastName, username, password, email, roll)
{
    public List<Class> Classes { get; set; }

}