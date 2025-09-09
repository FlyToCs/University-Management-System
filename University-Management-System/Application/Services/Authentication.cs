using University_Management_System.Application.Exceptions;
using University_Management_System.Domain.Contracts.Service_Contracts;
using University_Management_System.Domain.Entities;
using University_Management_System.Domain.Enums;

namespace University_Management_System.Application.Services
{
    public class Authentication : IAuthentication
    {

        public User Login(string email, string password)
        {

            EmailValidation(email);

            User foundUser = null!;
            // foreach (var user in Storage.UserList)
            // {
            //     if (user.Email != null && user.Email.ToLower() == email.ToLower())
            //     {
            //         foundUser = user;
            //         break;
            //     }
            // }
            //
            // if (foundUser == null)
            // {
            //     throw new UserNotFoundException("User not found in the system.");
            // }
            //
            // if (foundUser.Password != password)
            // {
            //     throw new InvalidPasswordException("Password is incorrect.");
            // }

            return foundUser;
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
            User newUsr = null!;
            if (role == RoleEnum.Student)
            {
                newUsr = new Student(1, firstName, lastname, userName, password, email, RoleEnum.Student);
                
            }
            else if (role == RoleEnum.Teacher)
            {
                newUsr = new Teacher(1, firstName, lastname, userName, password, email, RoleEnum.Teacher);
                
            }
            else if (role == RoleEnum.Operator)
            {
                newUsr = new Operator(1, firstName, lastname, userName, password, email, RoleEnum.Operator);
                
            }

            return newUsr;
        }
    }
}
