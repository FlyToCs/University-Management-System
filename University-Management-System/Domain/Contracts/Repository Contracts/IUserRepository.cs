using University_Management_System.Domain.Entities;

namespace University_Management_System.Domain.Contracts.Repository_Contracts;

public interface IUserRepository
{
    User AddUser(User user);
    User GetUserById(int id);
    List<User> GetAllUsers();
    void DeleteUser(User user);
    void UpdateUser(User user);
    int GetMaxId();


}