using System.ComponentModel;
using University_Management_System.Domain.Enums;
using University_Management_System.Domain.Exceptions;

namespace University_Management_System.Domain.Entities;

public class User
{

    public int Id { get; private set; } 
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string? Email { get; set; } 
    public string UserName { get; set; } 
    private string Password { get; set; } 
    public bool IsActive { get; private set; } = false;
    public RoleEnum Role { get; set; } 

    public User()
    {
        
    }

    public User(int id, string firstName, string lastName, string username, string password, string email, RoleEnum role)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        UserName = username;
        Password = password;
        Email = email;
        Role = role;
    }

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