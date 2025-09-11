using University_Management_System.Domain.Contracts.Repository_Contracts;
using University_Management_System.Domain.Contracts.Service_Contracts;
using University_Management_System.Domain.Entities;
using University_Management_System.Domain.Enums;

namespace University_Management_System.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly ICourseRepository _courseRepo;
    private readonly IClassRepository _classRepo;
    private readonly IUserRepository _userRepository;

    public TeacherService(ICourseRepository courseRepo, IClassRepository classRepo, IUserRepository userRepository)
    {
        _courseRepo = courseRepo;
        _classRepo = classRepo;
        _userRepository = userRepository;
    }


    public Course CreateCourse(string name, string description, int unit)
    {
        var course = new Course(0, name, description, unit);
        _courseRepo.Add(course);
        return course;
    }


    public void AddPrerequisite(Course course, Course prerequisite)
    {
        course.AddPrerequisite(prerequisite);
        _courseRepo.Update(course);
    }


    public Class CreateClass(int courseId, int teacherId, int capacity, string className)
    {
        var course = _courseRepo.GetById(courseId) ?? throw new Exception("Course not found");

        var user = _userRepository.GetUserById(teacherId);
        if (user is not Teacher teacher)
            throw new Exception("Teacher not found");

        var newClass = new Class(0, className, teacher, course, capacity);
        _classRepo.Add(newClass);
        return newClass;
    }


    public void AddScheduleToClass(int classId, DayOfWeek day, TimeSpan start, TimeSpan end)
    {
        var classObj = _classRepo.GetById(classId) ?? throw new Exception("Class not found");

        var schedules = classObj.Schedules.ToList(); // کپی لیست فعلی
        schedules.Add(new ClassSchedule(day, start, end));
        classObj.SetSchedules(schedules);

        _classRepo.Update(classObj);
    }


    public void SetClassCapacity(int classId, int capacity)
    {
        var classObj = _classRepo.GetById(classId) ?? throw new Exception("Class not found");
        classObj.SetCapacity(capacity);
        _classRepo.Update(classObj);
    }


    public List<Class> GetTeacherClasses(int teacherId)
    {
        var allClasses = _classRepo.GetAll(); 
        return allClasses.Where(c => c.Teacher != null && c.Teacher.Id == teacherId).ToList();
    }


    public List<Student> GetEnrolledStudents(int classId)
    {
        var classObj = _classRepo.GetById(classId) ?? throw new Exception("Class not found");
        return classObj.Students.ToList(); 
    }
}
