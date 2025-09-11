using University_Management_System.Domain.Entities;

namespace University_Management_System.Domain.Contracts.Service_Contracts;

public interface ICourseService
{
    Course CreateCourse(string name, int unit, string description, List<Course> prerequisites);
    void UpdateCourse(Course course);
    void DeleteCourse(int id);
    Course? GetCourseById(int id);
    List<Course> GetAllCourses();
}