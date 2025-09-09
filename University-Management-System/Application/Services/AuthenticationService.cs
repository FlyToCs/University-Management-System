using University_Management_System.Application.Exceptions;
using University_Management_System.Domain.Contracts.Service_Contracts;
using University_Management_System.Domain.Entities;
using University_Management_System.Domain.Enums;

namespace University_Management_System.Application.Services
{
    public class AuthenticationService : IAuthentication
    {
        
        private readonly IUserService _userService = new UserService();
        public User Login(string userName, string password)
        {
            foreach (var user in _userService.GetUsers())
            {
                if (user.UserName.ToLower() == userName.ToLower())
                {
                    return user;
                }
            }

            throw new UserNotFoundException("The username or password doesn't match");
        }



        public void EmailValidation(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidEmailException("Email is empty or invalid.");
            }

            int atCount = 0;
            foreach (char c in email)
            {
                if (c == '@') atCount++;
            }

            if (atCount != 1)
            {
                throw new InvalidEmailException("Email is invalid. It must contain exactly one '@'.");
            }

            int atIndex = email.IndexOf('@');
            if (atIndex < 1 || atIndex == email.Length - 1 || !email.Substring(atIndex + 1).Contains('.'))
            {
                throw new InvalidEmailException("Email is invalid. Must have at least one '.' after '@'.");
            }
        }

        public User Register(string firstName, string lastname, string userName, string password, string email, RoleEnum role)
        {
            EmailValidation(email);


            //User newUser;
            User newUser = new User();
            if (role == RoleEnum.Student)
            {
                  newUser = new Student(1, firstName, lastname, userName, password, email, RoleEnum.Student);
                 _userService.AddUser(newUser);
            }


            else if (role == RoleEnum.Teacher)
            {
                 newUser = new Teacher(1, firstName, lastname, userName, password, email, RoleEnum.Teacher);
                _userService.AddUser(newUser);
            }


            else if (role == RoleEnum.Operator)
            {
                 newUser = new Operator(1, firstName, lastname, userName, password, email, RoleEnum.Operator);
                _userService.AddUser(newUser);
            }



            return newUser;
        }
    }
}
