

using Figgle.Fonts;
using MiniMessenger.Framework;
using Spectre.Console;
using University_Management_System.Application.Services;
using University_Management_System.Domain.Contracts.Service_Contracts;
using University_Management_System.Domain.Entities;
using University_Management_System.Domain.Enums;
using University_Management_System.Infrastructure.Repositories;

Console.OutputEncoding = System.Text.Encoding.UTF8;


var userRepository = new FileUserRepository();
var courseRepository = new FileCourseRepository();

var classRepository = new FileClassRepository(userRepository, courseRepository);
Session session = new Session();
IStudentService studentService = new StudentService(userRepository, new ClassService(classRepository));
IUserService userService = new UserService();
IClassService classService = new ClassService(classRepository);
ITeacherService teacherService = new TeacherService(courseRepository, classRepository, userRepository);
ICourseService courseService = new CourseService(courseRepository);
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
                        //void StudentMenu(Student student, IStudentService studentService, IUserService userService, IClassService classService)
                        StudentMenu((Student)loginUser, studentService, userService, classService);
                    }
                    else if (loginUser.Role == RoleEnum.Teacher)
                    {
                        TeacherMenu((Teacher)loginUser);
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




void TeacherMenu(Teacher teacher)
{

    while (true)
    {
        try
        {
            Console.Clear();
            ConsolePainter.CyanMessage("======================================================================");
            ConsolePainter.YellowMessage(FiggleFonts.Standard.Render("Teacher Menu"));
            ConsolePainter.CyanMessage("======================================================================\n\n\n");

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[mediumspringgreen]🔰 Select an action:[/]")
                    .AddChoices(new[]
                    {
                    "Profile",
                    "Edit information",
                    "Add a course",
                    "Course list",
                    "Create a class",
                    "Add schedule to class",
                    "Set class capacity",
                    "View students of a class",
                    "Logout"
                    }));

            switch (choice)
            {
                case "Profile":
                    ConsolePainter.GreenMessage($"\n👤 Profile Info:");
                    Console.WriteLine($"ID: {teacher.Id}");
                    Console.WriteLine($"Name: {teacher.FirstName} {teacher.LastName}");
                    Console.WriteLine($"Username: {teacher.UserName}");
                    Console.WriteLine($"Email: {teacher.Email}");
                    Console.WriteLine($"Teacher Number: {teacher.TeNumber}");
                    Console.ReadKey();
                    break;

                case "Edit information":
                    Console.Write("New First Name: ");
                    teacher.FirstName = Console.ReadLine()!;
                    Console.Write("New Last Name: ");
                    teacher.LastName = Console.ReadLine()!;
                    Console.Write("New Email: ");
                    teacher.Email = Console.ReadLine()!;
                    userService.UpdateUser(teacher);
                    ConsolePainter.GreenMessage("Information updated successfully!");
                    Console.ReadKey();
                    break;

                case "Add a course":
                    Console.Write("Course Name: ");
                    string name = Console.ReadLine()!;
                    Console.Write("Description: ");
                    string desc = Console.ReadLine()!;
                    Console.Write("Units: ");
                    int unit = int.Parse(Console.ReadLine()!);
                    var newCourse = teacherService.CreateCourse(name, desc, unit);
                    ConsolePainter.GreenMessage($"Course '{newCourse.Name}' created successfully!");
                    Console.ReadKey();
                    break;

                case "Course list":
                    var courses = courseService.GetAllCourses();
                    ConsolePainter.GreenMessage("\n📚 All Courses:");
                    foreach (var c in courses)
                    {
                        Console.WriteLine($"[{c.Id}] {c.Name} ({c.Unit} units)");
                    }
                    Console.ReadKey();
                    break;

                case "Create a class":
                    var allCoursesForClass = courseService.GetAllCourses();
                    ConsolePainter.GreenMessage("\n📚 Available Courses:");
                    foreach (var c in allCoursesForClass)
                        Console.WriteLine($"[{c.Id}] {c.Name} ({c.Unit} units)");

                    Console.Write("Course ID to create class for: ");
                    int courseId = int.Parse(Console.ReadLine()!);

                    Console.Write("Class Name: ");
                    string className = Console.ReadLine()!;

                    Console.Write("Capacity: ");
                    int capacity = int.Parse(Console.ReadLine()!);

                    Console.Write("Start time (yyyy-MM-dd HH:mm): ");
                    DateTime startClass = DateTime.Parse(Console.ReadLine()!);

                    Console.Write("End time (yyyy-MM-dd HH:mm): ");
                    DateTime endClass = DateTime.Parse(Console.ReadLine()!);

                    // ✅ تغییر اینجا
                    var teacherClass = (Teacher)session.CurrentUser!;
                    var course = courseService.GetCourseById(courseId);
                    var newClass = classService.CreateClass(className, teacherClass, course, capacity, startClass, endClass);

                    ConsolePainter.GreenMessage(
                        $"Class '{newClass.ClassName}' created successfully from {startClass} to {endClass}!"
                    );
                    Console.ReadKey();
                    break;

                case "Add schedule to class":
                    var allClasses = classService.GetAllClasses();
                    ConsolePainter.GreenMessage("\n🏫 Available Classes:");
                    foreach (var cl in allClasses)
                        Console.WriteLine($"[{cl.Id}] {cl.ClassName} - {cl.Course.Name}");

                    Console.Write("Class ID: ");
                    int classId = int.Parse(Console.ReadLine()!);
                    Console.Write("Day of week (0=Sunday,...,6=Saturday): ");
                    DayOfWeek day = (DayOfWeek)int.Parse(Console.ReadLine()!);
                    Console.Write("Start Time (HH:mm): ");
                    TimeSpan start = TimeSpan.Parse(Console.ReadLine()!);
                    Console.Write("End Time (HH:mm): ");
                    TimeSpan end = TimeSpan.Parse(Console.ReadLine()!);
                    teacherService.AddScheduleToClass(classId, day, start, end);
                    ConsolePainter.GreenMessage("Schedule added successfully!");
                    Console.ReadKey();
                    break;

                case "Set class capacity":
                    ConsolePainter.GreenMessage("\n🏫 Available Classes:");
                    var classes = classService.GetAllClasses();
                    foreach (var cl in classes)
                        Console.WriteLine($"[{cl.Id}] {cl.ClassName} - {cl.Course.Name}");

                    Console.Write("Class ID: ");
                    int cid = int.Parse(Console.ReadLine()!);
                    Console.Write("New Capacity: ");
                    int newCap = int.Parse(Console.ReadLine()!);
                    teacherService.SetClassCapacity(cid, newCap);
                    ConsolePainter.GreenMessage("Class capacity updated successfully!");
                    Console.ReadKey();
                    break;

                case "View students of a class":
                    ConsolePainter.GreenMessage("\n🏫 Available Classes:");
                    foreach (var cl in classService.GetAllClasses())
                        Console.WriteLine($"[{cl.Id}] {cl.ClassName} - {cl.Course.Name}");

                    Console.Write("Class ID: ");
                    int clsId = int.Parse(Console.ReadLine()!);
                    var students = teacherService.GetEnrolledStudents(clsId);
                    foreach (var s in students)
                    {
                        ConsolePainter.CyanMessage($"ID: {s.Id}, Name: {s.FirstName} {s.LastName}, StNumber: {s.StNumber}");
                    }
                    Console.ReadKey();
                    break;

                case "Logout":
                    session.Logout();
                    AuthenticationMenu();
                    return;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadKey();
        }
    }


}




void StudentMenu(Student student, IStudentService studentService, IUserService userService, IClassService classService)
{

    while (true)
    {

        try
        {
            Console.Clear();
            ConsolePainter.CyanMessage("======================================================================");
            ConsolePainter.YellowMessage(FiggleFonts.Standard.Render("Student Menu"));
            ConsolePainter.CyanMessage("======================================================================\n\n\n");

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
                    ConsolePainter.GreenMessage($"\n👤 Profile Info:");
                    Console.WriteLine($"ID: {student.Id}");
                    Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
                    Console.WriteLine($"Username: {student.UserName}");
                    Console.WriteLine($"Email: {student.Email}");
                    Console.WriteLine($"Student Number: {student.StNumber}");
                    Console.ReadKey();
                    break;

                case "Edit information":
                    Console.Write("New Email: ");
                    student.Email = Console.ReadLine()!;
                    userService.UpdateUser(student);
                    ConsolePainter.GreenMessage("Profile updated successfully!");
                    Console.ReadKey();
                    break;

                case "Course registration":
                    var classes = studentService.ViewAllClasses();
                    if (classes.Count == 0)
                    {
                        ConsolePainter.RedMessage("No classes available.");
                        Console.ReadKey();
                        break;
                    }

                    ConsolePainter.GreenMessage("\n📚 Available Classes:");
                    foreach (var cl in classes)
                    {
                        Console.WriteLine($"[{cl.Id}] {cl.ClassName} - {cl.Course.Name} ({cl.Course.Unit} units) - Capacity: {cl.Capacity}");
                    }

                    Console.Write("\nEnter Class ID to register: ");
                    if (int.TryParse(Console.ReadLine(), out int classId))
                    {
                        try
                        {
                            studentService.RegisterInClass(student.Id, classId);
                            ConsolePainter.GreenMessage("Class registered successfully!");
                        }
                        catch (Exception ex)
                        {
                            ConsolePainter.RedMessage($"❌ {ex.Message}");
                        }
                    }
                    else
                    {
                        ConsolePainter.RedMessage("Invalid input.");
                    }
                    Console.ReadKey();
                    break;
                case "View the list of registered courses":
                    
                    var registeredClasses = studentService.ViewRegisteredClasses(student.Id);
                    if (registeredClasses.Count == 0)
                    {
                        ConsolePainter.RedMessage("You have not registered any course.");
                    }
                    else
                    {
                        ConsolePainter.GreenMessage("\n📖 Registered Courses:");
                        foreach (var cl in registeredClasses)
                        {
                            string teacherName = cl.Teacher != null
                                ? $"{cl.Teacher.FirstName} {cl.Teacher.LastName}"
                                : "Unknown Teacher";

                            Console.WriteLine($"- {cl.Course.Name} ({cl.Course.Unit} units) with {teacherName}");
                        }
                    }
                    Console.ReadKey();
                    break;


                case "View class schedule":
                    var schedule = studentService.ViewSchedule(student.Id);
                    if (schedule.Count == 0)
                    {
                        ConsolePainter.RedMessage("No schedule found.");
                    }
                    else
                    {
                        ConsolePainter.GreenMessage("\n🗓️ Your Class Schedule:");
                        foreach (var cl in schedule)
                        {
                            Console.WriteLine($"{cl.ClassName} - {cl.Course.Name}");
                            foreach (var sch in cl.Schedules)
                            {
                                Console.WriteLine($"  {sch.Day}: {sch.StartTime:HH:mm} - {sch.EndTime:HH:mm}");
                            }
                        }
                    }
                    Console.ReadKey();
                    break;

                case "Logout":
                    session.Logout();
                    AuthenticationMenu();
                    return;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadKey();
        }

    }
}

void OperatorMenu()
{
    var authService = new AuthenticationService();
    var userService = new UserService();

    while (true)
    {
        Console.Clear();
        ConsolePainter.CyanMessage("======================================================================");
        ConsolePainter.YellowMessage(FiggleFonts.Standard.Render("Operator Menu"));
        ConsolePainter.CyanMessage("======================================================================\n\n\n");

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[mediumspringgreen]🔰 Select an action:[/]")
                .AddChoices(new[]
                {
                    "View all users",
                    "Add user",
                    "Activate user",
                    "Deactivate user",
                    "Delete user",
                    "Exit"
                }));

        switch (choice)
        {
            case "View all users":
                var allUsers = userService.GetUsers();
                if (allUsers.Count == 0)
                {
                    ConsolePainter.RedMessage("No users found.");
                }
                else
                {
                    ConsolePainter.GreenMessage("\n👥 Users List:");
                    foreach (var u in allUsers)
                    {
                        string role = u.Role.ToString();
                        string status = u.IsActive ? "Active" : "Inactive";
                        Console.WriteLine($"ID: {u.Id} | {u.FirstName} {u.LastName} | Username: {u.UserName} | Role: {role} | Status: {status}");
                    }
                }
                Console.ReadKey();
                break;

            case "Add user":
                Console.Write("First Name: ");
                string firstName = Console.ReadLine()!;
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine()!;
                Console.Write("Username: ");
                string username = Console.ReadLine()!;
                Console.Write("Email: ");
                string email = Console.ReadLine()!;
                Console.WriteLine("Select Role: 0=Student, 1=Teacher, 2=Operator");
                int roleInt = int.Parse(Console.ReadLine()!);
                var roleEnum = (RoleEnum)roleInt;

                try
                {
                    var newUser = authService.Register(firstName, lastName, username, "defaultPassword", email, roleEnum);
                    ConsolePainter.GreenMessage($"User {newUser.FirstName} {newUser.LastName} created successfully!");
                }
                catch (Exception ex)
                {
                    ConsolePainter.RedMessage($"❌ {ex.Message}");
                }

                Console.ReadKey();
                break;

            case "Activate user":
                Console.Write("Enter user ID to activate: ");
                int activateId = int.Parse(Console.ReadLine()!);
                var userToActivate = userService.GetUser(activateId);
                if (userToActivate != null)
                {
                    userToActivate.Activate();
                    userService.UpdateUser(userToActivate);
                    ConsolePainter.GreenMessage("User activated successfully!");
                }
                else
                {
                    ConsolePainter.RedMessage("User not found.");
                }
                Console.ReadKey();
                break;

            case "Deactivate user":
                Console.Write("Enter user ID to deactivate: ");
                int deactivateId = int.Parse(Console.ReadLine()!);
                var userToDeactivate = userService.GetUser(deactivateId);
                if (userToDeactivate != null)
                {
                    userToDeactivate.Deactivate();
                    userService.UpdateUser(userToDeactivate);
                    ConsolePainter.GreenMessage("User deactivated successfully!");
                }
                else
                {
                    ConsolePainter.RedMessage("User not found.");
                }
                Console.ReadKey();
                break;

            case "Delete user":
                Console.Write("Enter user ID to delete: ");
                int deleteId = int.Parse(Console.ReadLine()!);
                var userToDelete = userService.GetUser(deleteId);
                if (userToDelete != null)
                {
                    userService.DeleteUser(userToDelete.Id);
                    ConsolePainter.GreenMessage("User deleted successfully!");
                }
                else
                {
                    ConsolePainter.RedMessage("User not found.");
                }
                Console.ReadKey();
                break;

            case "Exit":
                return;
        }
    }
}

