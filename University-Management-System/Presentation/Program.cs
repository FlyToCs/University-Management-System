

using Figgle.Fonts;
using MiniMessenger.Framework;
using Spectre.Console;
using University_Management_System.Application.Services;
using University_Management_System.Domain.Contracts.Service_Contracts;
using University_Management_System.Domain.Entities;
using University_Management_System.Domain.Enums;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Session session = new Session();


IAuthentication authentication = new AuthenticationService();



AuthenticationMenu();

void AuthenticationMenu()
{

    while (true)
    {

        Console.Clear();
        ConsolePainter.CyanMessage("======================================================================");
        ConsolePainter.YellowMessage(FiggleFonts.Standard.Render("Authentication"));
        ConsolePainter.CyanMessage("======================================================================\n\n\n");
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[mediumspringgreen]🔰 Select an action:[/]")
                .AddChoices(new[]
                {
                    "Register",
                    "Login",
                    "Exit"
                }));
        try
        {
            switch (choice)
            {
                case "Register":
                    var choiceRole = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[mediumspringgreen]🔰 Register as:[/]")
                            .AddChoices(new[]
                            {
                            "Student",
                            "Teacher",
                            "Operator",
                            "Back to menu"
                            }));

                    if (choiceRole == "Back to menu")
                        AuthenticationMenu();


                    Console.Write("Enter firstname: ");
                    string newFirstName = Console.ReadLine()!;

                    Console.Write("Enter Lastname: ");
                    string newLastName = Console.ReadLine()!;

                    Console.Write("Enter Email: ");
                    string newEmail = Console.ReadLine()!;

                    Console.Write("Enter Username: ");
                    string newUserName = Console.ReadLine()!;

                    Console.Write("Enter Password: ");
                    string newPassword = Console.ReadLine()!;



                    if (choiceRole == "Student")
                        authentication.Register(newFirstName, newLastName, newUserName, newPassword, newEmail,
                            RoleEnum.Student);

                    else if (choiceRole == "Teacher")
                        authentication.Register(newFirstName, newLastName, newUserName, newPassword, newEmail,
                            RoleEnum.Teacher);

                    else if (choiceRole == "Operator")
                        authentication.Register(newFirstName, newLastName, newUserName, newPassword, newEmail,
                            RoleEnum.Operator);


                    ConsolePainter.GreenMessage("Registered successfully");
                    Console.ReadKey();

                    break;

                case "Login":
                    Console.Write("Enter username: ");
                    string userName = Console.ReadLine()!;

                    Console.Write("Enter password: ");
                    string password = Console.ReadLine()!;

                    var loginUser = authentication.Login(userName, password);
                    if (loginUser.Role == RoleEnum.Student)
                    {
                        StudentMenu();
                    }
                    else if (loginUser.Role == RoleEnum.Teacher)
                    {
                        TeacherMenu();
                    }
                    else if (loginUser.Role == RoleEnum.Operator)
                    {
                        OperatorMenu();
                    }
                    ConsolePainter.GreenMessage("You were login");
                    Console.ReadKey();

                    break;

                case "Exit":
                    Environment.Exit(-1);
                    break;
            }

        }
        catch (Exception e)
        {
            ConsolePainter.RedMessage(e.Message);
            Console.ReadKey();
        }

    }
}




void StudentMenu()
{
    Console.Clear();
    ConsolePainter.CyanMessage("======================================================================");
    ConsolePainter.YellowMessage(FiggleFonts.Standard.Render("Student Menu"));
    ConsolePainter.CyanMessage("======================================================================\n\n\n");
    while (true)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[mediumspringgreen]🔰 Select an action:[/]")
                .AddChoices(new[]
                {
                    "Profile",
                    "Edit information",
                    "Course registration",
                    "View the list of registered courses",
                    "View class schedule",
                    "Logout"
                }));

        switch (choice)
        {
            case "Profile":
                break;

            case "Edit information":
                break;

            case "Course registration":
                break;

            case "View the list of registered courses":
                break;

            case "View class schedule":
                break;

            case "Logout":
                session.Logout();
                AuthenticationMenu();
                break;
        }

    }
}

void TeacherMenu()
{
    Console.Clear();
    ConsolePainter.CyanMessage("======================================================================");
    ConsolePainter.YellowMessage(FiggleFonts.Standard.Render("Teacher Menu"));
    ConsolePainter.CyanMessage("======================================================================\n\n\n");
    while (true)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[mediumspringgreen]🔰 Select an action:[/]")
                .AddChoices(new[]
                {
                    "Register",
                    "Login",
                    "Exit"
                }));

        switch (choice)
        {
            case "Register":
                break;

            case "Login":
                break;

            case "Exit":
                Environment.Exit(-1);
                break;
        }

    }
}

void OperatorMenu()
{
    Console.Clear();
    ConsolePainter.CyanMessage("======================================================================");
    ConsolePainter.YellowMessage(FiggleFonts.Standard.Render("Operator Munu"));
    ConsolePainter.CyanMessage("======================================================================\n\n\n");
    while (true)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[mediumspringgreen]🔰 Select an action:[/]")
                .AddChoices(new[]
                {
                    "Register",
                    "Login",
                    "Exit"
                }));

        switch (choice)
        {
            case "Register":
                break;

            case "Login":
                break;

            case "Exit":
                Environment.Exit(-1);
                break;
        }

    }
}



Console.ReadKey();