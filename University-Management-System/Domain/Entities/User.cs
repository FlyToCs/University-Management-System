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
    RollEnum roll)
{

    public int Id { get; private set; } = id;
    public required string FirstName { get; set; } = firstName;
    public required string LastName { get; set; } = lastName;
    public string? Email { get; set; } = email;
    public required string UserName { get; set; } = username;
    private string Password { get; set; } = password;
    public bool IsActive { get; private set; } = false;
    public RollEnum Roll { get; set; } = roll;

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