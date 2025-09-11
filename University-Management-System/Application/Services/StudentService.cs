using University_Management_System.Domain.Contracts.Repository_Contracts;
using University_Management_System.Domain.Contracts.Service_Contracts;
using University_Management_System.Domain.Entities;

namespace University_Management_System.Application.Services;

public class StudentService : IStudentService
{
    private readonly IUserRepository _userRepository;
    private readonly IClassService _classService;

    public StudentService(IUserRepository userRepository, IClassService classService)
    {
        _userRepository = userRepository;
        _classService = classService;
    }

    public int GenerateStNumber()
    {
        var students = GetAllStudents();
        int maxStNumber = 0;

        foreach (var s in students)
        {
            if (s.StNumber > maxStNumber)
                maxStNumber = s.StNumber;
        }

        return maxStNumber + 1;
    }


    public List<Class> ViewAllClasses()
    {
        return _classService.GetAllClasses();
    }
    public List<Class> ViewRegisteredClasses(int studentId)
    {
        var student = _userRepository.GetUserById(studentId);
        if (student == null) return new List<Class>();


        var allClasses = _classService.GetAllClasses();
        return allClasses.Where(c => c.Students.Any(s => s.Id == studentId)).ToList();
    }


    public void RegisterInClass(int studentId, int classId)
    {
        var user = _userRepository.GetUserById(studentId);
        if (user is not Student student)
            throw new Exception("Student not found");

        var courseClass = _classService.GetClassById(classId);
        if (courseClass == null)
            throw new Exception("Class not found");


        courseClass.EnrollStudent(student);


        student.RegisterClass(courseClass);
        

        _userRepository.UpdateUser(student);
        _classService.UpdateClass(courseClass);
    }


    public List<Class> ViewSchedule(int studentId)
    {
        var user = _userRepository.GetUserById(studentId);
        if (user is not Student student)
            throw new Exception("Student not found");

        return student.Classes;
    }


    private List<Student> GetAllStudents()
    {
        var allUsers = _userRepository.GetAllUsers();
        var students = new List<Student>();

        foreach (var user in allUsers)
        {
            if (user is Student st)
                students.Add(st);
        }

        return students;
    }
}