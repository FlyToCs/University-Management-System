using University_Management_System.Domain.Entities;

namespace University_Management_System.Domain.Contracts.Service_Contracts;

public interface IOperatorService
{
    void AddUser(User user);
    void UpdateUser(User user);
    void RemoveUser(int userId);
    void ActivateUser(int userId);
    void DeactivateUser(int userId);
    User GetUserById(int userId);
    List<User> GetAllUsers();

    List<Class> GetAllClasses();
    void UpdateClassCapacity(int classId, int newCapacity);
}