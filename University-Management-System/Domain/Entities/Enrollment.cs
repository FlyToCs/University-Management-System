namespace University_Management_System.Domain.Entities;

public class Enrollment
{
    public int Id { get; private set; }
    public Student Student { get; private set; }
    public Class CourseClass { get; private set; }
    public DateTime RegisterDate { get; private set; }

    public Enrollment(int id, Student student, Class courseClass, DateTime registerDate)
    {
        Id = id;
        Student = student;
        CourseClass = courseClass;
        RegisterDate = registerDate;
    }
}