using University_Management_System.Domain.Entities;

namespace MiniMessenger.Framework;

public class Session
{
    public User? CurrentUser { get; set; }
    public bool IsLogin { get; set; }

    public void Login(User user)
    {
        CurrentUser = user;
        IsLogin = true;
    }

    public void Logout()
    {
        CurrentUser = null!;
        IsLogin = false;
    }

}