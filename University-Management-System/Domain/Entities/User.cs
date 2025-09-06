using System.ComponentModel;

namespace University_Management_System.Domain.Entities;

public class User
{
    private static int _idSet;
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public bool IsActive { get; set; }


    public User()
    {
        Id = ++_idSet;
    }
}