using University_Management_System.Domain.Entities;

namespace University_Management_System.Domain.Contracts.Service_Contracts;

public interface IClassService
{
    Class CreateClass(string className, Teacher teacher, Course course, int capacity, DateTime start, DateTime end);
    void UpdateClass(Class courseClass);
    void DeleteClass(int id);
    Class? GetClassById(int id);
    List<Class> GetAllClasses();
    List<Class> GetClassesByCourse(int courseId);
    List<Class> GetClassesByTeacher(int teacherId);
    void AddStudentToClass(int classId, Student student);
}