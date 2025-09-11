using University_Management_System.Domain.Entities;

namespace University_Management_System.Domain.Contracts.Repository_Contracts;

public interface IClassRepository
{
    Class Add(Class courseClass);
    void Update(Class courseClass);
    void Delete(int id);
    Class? GetById(int id);
    List<Class> GetAll();
    List<Class> GetByCourseId(int courseId);
    List<Class> GetByTeacherId(int teacherId);
    int GetMaxId();
}