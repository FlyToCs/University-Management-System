

using Figgle.Fonts;
using MiniMessenger.Framework;
using Spectre.Console;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Session session = new Session();






AuthenticationMenu();

void AuthenticationMenu()
{
    Console.Clear();
    ConsolePainter.CyanMessage("======================================================================");
    ConsolePainter.YellowMessage(FiggleFonts.Standard.Render("Authentication"));
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