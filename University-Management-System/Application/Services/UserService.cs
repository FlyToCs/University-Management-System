using University_Management_System.Domain.Contracts.Repository_Contracts;
using University_Management_System.Domain.Contracts.Service_Contracts;
using University_Management_System.Domain.Entities;
using University_Management_System.Infrastructure.Repositories;

namespace University_Management_System.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository = new FileUserRepository();
    public User AddUser(User user)
    {
       return _userRepository.AddUser(user);
    }

    public User GetUser(int id)
    {
        return _userRepository.GetUserById(id);
    }

    public void UpdateUser(User user)
    {
        _userRepository.UpdateUser(user);
    }

    public List<User> GetUsers()
    {
        return _userRepository.GetAllUsers();
    }
}