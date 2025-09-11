using University_Management_System.Domain.Contracts.Service_Contracts;
using University_Management_System.Domain.Entities;

namespace University_Management_System.Application.Services;

public class OperatorService : IOperatorService
{
    private readonly IUserService _userService;
    private readonly IClassService _classService;

    public OperatorService(IUserService userService, IClassService classService)
    {
        _userService = userService;
        _classService = classService;
    }

    public void AddUser(User user)
    {
        user.SetId(_userService.GenerateUserId());
        _userService.AddUser(user);
    }

    public void UpdateUser(User user)
    {
        _userService.UpdateUser(user);
    }

    public void RemoveUser(int userId)
    {
        var user = _userService.GetUser(userId);
        if (user != null)
            _userService.UpdateUser(user); 
    }

    public void ActivateUser(int userId)
    {
        var user = _userService.GetUser(userId);
        if (user != null)
        {
            user.Activate();
            _userService.UpdateUser(user);
        }
    }

    public void DeactivateUser(int userId)
    {
        var user = _userService.GetUser(userId);
        if (user != null)
        {
            user.Deactivate();
            _userService.UpdateUser(user);
        }
    }

    public User GetUserById(int userId)
    {
        return _userService.GetUser(userId);
    }

    public List<User> GetAllUsers()
    {
        return _userService.GetUsers();
    }

    public List<Class> GetAllClasses()
    {
        return _classService.GetAllClasses();
    }

    public void UpdateClassCapacity(int classId, int newCapacity)
    {
        var cls = _classService.GetClassById(classId);
        if (cls != null)
        {
            cls.SetCapacity(newCapacity);
            _classService.UpdateClass(cls);
        }
    }
}