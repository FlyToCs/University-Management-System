using University_Management_System.Domain.Contracts.Repository_Contracts;
using University_Management_System.Domain.Contracts.Service_Contracts;
using University_Management_System.Domain.Entities;

namespace University_Management_System.Application.Services;

public class ClassService : IClassService
{
    private readonly IClassRepository _classRepository;

    public ClassService(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }

    public Class CreateClass(string className, Teacher teacher, Course course, int capacity, DateTime start, DateTime end)
    {
        int newId = _classRepository.GetMaxId() + 1;
        var newClass = new Class(newId, className, teacher, course, new List<Student>(), start, end, capacity);
        return _classRepository.Add(newClass);
    }

    public void UpdateClass(Class courseClass)
    {
        _classRepository.Update(courseClass);
    }

    public void DeleteClass(int id)
    {
        _classRepository.Delete(id);
    }

    public Class? GetClassById(int id)
    {
        return _classRepository.GetById(id);
    }

    public List<Class> GetAllClasses()
    {
        return _classRepository.GetAll();
    }

    public List<Class> GetClassesByCourse(int courseId)
    {
        return _classRepository.GetByCourseId(courseId);
    }

    public List<Class> GetClassesByTeacher(int teacherId)
    {
        return _classRepository.GetByTeacherId(teacherId);
    }

    public void AddStudentToClass(int classId, Student student)
    {
        var courseClass = _classRepository.GetById(classId);
        if (courseClass == null) 
            throw new Exception("Class not found");

        if (courseClass.Students.Count >= courseClass.Capacity)
            throw new Exception("Class is full");

        courseClass.Students.Add(student);
        _classRepository.Update(courseClass);
    }
}