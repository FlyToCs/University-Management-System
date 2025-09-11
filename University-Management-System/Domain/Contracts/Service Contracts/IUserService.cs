using University_Management_System.Domain.Entities;

namespace University_Management_System.Domain.Contracts.Service_Contracts;

public interface IUserService
{
    User AddUser(User user);
    User GetUser(int id);
    void UpdateUser(User user);
    List<User> GetUsers();
    void DeleteUser(int userId);
    int GenerateUserId();
}