using System.ComponentModel;
using University_Management_System.Domain.Enums;
using University_Management_System.Domain.Exceptions;

namespace University_Management_System.Domain.Entities;

public class User(
    int id,
    string firstName,
    string lastName,
    string username,
    string password,
    string email,
    RoleEnum role)
{

    public int Id { get; private set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string? Email { get; set; } = email;
    public string UserName { get; set; } = username;
    private string Password { get; set; } = password;
    public bool IsActive { get; private set; } = false;
    public RoleEnum Role { get; set; } = role;

    public void Activate()
    {
        IsActive = true;
    }

    public void DeActivate()
    {
        IsActive = false;
    }


    public virtual void EnsurePassword(string password)
    {
        if (password.Length < 3)
        {
            throw new PasswordValidationException("Password should contain at least 3 characters");
        }
    }
    public void ChangePassword(string oldPassword, string newPassword)
    {
        EnsurePassword(newPassword);
        if (oldPassword == Password)
            Password = newPassword;
        else
            throw new PasswordValidationException("The old password doesn't match");
    }

    public bool CheckPassword(string password)
    {
        return Password == password;
    }

}