using University_Management_System.Domain.Enums;

namespace University_Management_System.Domain.Entities;

public class Student(int id, string firstName, string lastName, string username, string password, string email, RoleEnum role) : User(id, firstName, lastName, username, password, email, role)
{
    public int StNumber { get; private set; }
    public List<Enrollment> Classes { get; set; } = new();

}