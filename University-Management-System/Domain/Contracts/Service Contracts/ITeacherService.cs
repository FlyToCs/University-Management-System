using University_Management_System.Domain.Entities;

namespace University_Management_System.Domain.Contracts.Service_Contracts;

public interface ITeacherService
{
    Course CreateCourse(string name, string description, int unit);
    void AddPrerequisite(Course course, Course prerequisite);

    Class CreateClass(int courseId, int teacherId, int capacity, string className);
    void AddScheduleToClass(int classId, DayOfWeek day, TimeSpan start, TimeSpan end);
    void SetClassCapacity(int classId, int capacity);

    List<Class> GetTeacherClasses(int teacherId);
    List<Student> GetEnrolledStudents(int classId);

}