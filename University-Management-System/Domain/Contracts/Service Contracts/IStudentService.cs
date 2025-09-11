using University_Management_System.Domain.Entities;

namespace University_Management_System.Domain.Contracts.Service_Contracts;

public interface IStudentService
{
    int GenerateStNumber();
    List<Class> ViewAllClasses();  
    List<Class> ViewRegisteredClasses(int id);
    void RegisterInClass(int studentId, int classId);  
    List<Class> ViewSchedule(int studentId); 
}