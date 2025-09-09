

using Figgle.Fonts;
using MiniMessenger.Framework;
using Spectre.Console;
using University_Management_System.Application.Services;
using University_Management_System.Domain.Contracts.Service_Contracts;
using University_Management_System.Domain.Enums;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Session session = new Session();


IAuthentication authentication = new AuthenticationService();



AuthenticationMenu();

void AuthenticationMenu()
{
    Console.Clear();
    ConsolePainter.CyanMessage("======================================================================");
    ConsolePainter.YellowMessage(FiggleFonts.Standard.Render("AuthenticationService"));
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
                var choiceRole = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[mediumspringgreen]🔰 Register as:[/]")
                        .AddChoices(new[]
                        {
                            "Student",
                            "Teacher",
                            "Operator"
                        }));
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

                if (choiceRole == "Teacher")
                    authentication.Register(newFirstName, newLastName, newUserName, newPassword, newEmail,
                        RoleEnum.Teacher);

                if (choiceRole == "Operator")
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

                authentication.Login(userName, password);
                ConsolePainter.GreenMessage("You were login");
                Console.ReadKey();

                break;

            case "Exit":
                Environment.Exit(-1);
                break;
        }

    }
}




void StudnetMenu()
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