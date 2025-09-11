using University_Management_System.Domain.Contracts.Repository_Contracts;
using University_Management_System.Domain.Contracts.Service_Contracts;
using University_Management_System.Domain.Entities;

namespace University_Management_System.Application.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public Course CreateCourse(string name, int unit, string description, List<Course> prerequisites)
    {
        int newId = _courseRepository.GetMaxId() + 1;
        var course = new Course(newId, name, description, unit);

        foreach (var pre in prerequisites)
        {
            course.AddPrerequisite(pre);
        }

        return _courseRepository.Add(course);
    }

    public void UpdateCourse(Course course)
    {
        _courseRepository.Update(course);
    }

    public void DeleteCourse(int id)
    {
        _courseRepository.Delete(id);
    }

    public Course? GetCourseById(int id)
    {
        return _courseRepository.GetById(id);
    }

    public List<Course> GetAllCourses()
    {
        return _courseRepository.GetAll();
    }
}