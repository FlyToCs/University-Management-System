using University_Management_System.Domain.Entities;

namespace University_Management_System.Domain.Contracts.Repository_Contracts;

public interface ICourseRepository
{
    Course Add(Course course);
    void Update(Course course);
    void Delete(int id);
    Course? GetById(int id);
    List<Course> GetAll();
    int GetMaxId();
}