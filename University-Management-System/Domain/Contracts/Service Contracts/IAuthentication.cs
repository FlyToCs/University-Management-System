

using University_Management_System.Domain.Entities;
using University_Management_System.Domain.Enums;

namespace University_Management_System.Domain.Contracts.Service_Contracts;

public interface IAuthentication
{
    User? Login(string email, string password);
    User? Register(string firstName, string lastname, string userName, string password, string email, RoleEnum role);
}