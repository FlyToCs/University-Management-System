using Newtonsoft.Json;
using University_Management_System.Domain.Enums;

namespace University_Management_System.Domain.Entities;

public class Student(int id, string firstName, string lastName, string username, string password, string email, RoleEnum role) : User(id, firstName, lastName, username, password, email, role)
{
    public int StNumber { get; private set; }

    public List<Course> PassedCourses { get; private set; }
    
    [JsonProperty]
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

    private int GetRegisteredUnit()
    {
        int unit = 0;
        foreach (var cl in Classes)
        {
           unit += cl.Course.Unit;
        }
        return unit;
    }

    
    public void AddPassedCourse(Course course)
    {
        PassedCourses.Add(course);
    }

    public void ChangeStatusToAbsent()
    {
        StudentStatus = StudentStatus.Absent;
    }
    public void ChangeStatusToNormal()
    {
        StudentStatus = StudentStatus.Normal;
    }
    public void ChangeStatusToProbational()
    {
        StudentStatus = StudentStatus.Probational;
    }
    public void ChangeStatusToVacation()
    {
        StudentStatus = StudentStatus.Vacation;
    }

    public void RegisterClass(Class cl)
    {
        if (IsCourseRegistered(cl.Course.Name))
            throw new Exception("you already Registered in this course.");
        if (IsCoursePassed(cl.Course.Name))
            throw new Exception("Student passed this course before.");

        if (StudentStatus == StudentStatus.Vacation)
            throw new Exception("you're in vacation, so you can't register a course in this term");

        else if (StudentStatus == StudentStatus.Absent)
            throw new Exception("you absent, so you can't register a course in this term");

        else if (StudentStatus == StudentStatus.Probational)
        {
            if (GetRegisteredUnit() > 6)
                throw new Exception("You can't registered this course because you were Probational ");
        }
        else if (StudentStatus == StudentStatus.Normal)
        {
            if (GetRegisteredUnit() > 10)
                throw new Exception("You can't registered more than 10 units ");
        }
        Classes.Add(cl);
    }

}