using Newtonsoft.Json;
using University_Management_System.Domain.Enums;

namespace University_Management_System.Domain.Entities;

public class Student(int id, string firstName, string lastName, string username, string password, string email, RoleEnum role) : User(id, firstName, lastName, username, password, email, role)
{
    public int StNumber { get; private set; }

    public List<Course> PassedCourses { get; private set; }
    public List<Class> Classes { get; private set; }
    public StudentStatus StudentStatus { get; set; }

    [JsonConstructor]
    public Student(int id,int stNumber, string firstName, string lastName, string username, string password, string email, RoleEnum role) : this( id,  firstName,  lastName,  username,  password,  email,  role)
    {
        StNumber = stNumber;
        PassedCourses = new();
        Classes = new();
        StudentStatus = StudentStatus.Normal;
    }

    public bool IsCoursePassed(string courseName)
    {
        foreach (var passedCourse in PassedCourses)
        {
            if (passedCourse.Name == courseName)
                return true;
        }
        return false;
    }

    public bool IsCourseRegistered(string courseName)
    {
        foreach (var cl in Classes)
        {
            if (cl.Course.Name == courseName)
                return true;
        }
        return false;
    }

    public int CalculateTotalUnit()
    {
        int sum = 0;
        foreach (var cl in Classes)
        {
            sum += cl.Course.Unit;
        }
        return sum;
    }
    public void AddPassedCourse(Course course)
    {
        if (IsCoursePassed(course.Name))
            throw new Exception("You can't register in this course. because you passed it before");

        PassedCourses.Add(course);
    }

    public void RegisterClass(Class cl)
    {



        Classes.Add(cl);
    }

}