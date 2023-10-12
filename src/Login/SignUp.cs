using Almacen.Models;

namespace Almacen.Login;
public class SignUp
{
    public const string gStoreKeeper = "StoreKeeper", gTeacher = "Teacher", gStudent = "Student";
    //Console Sign Up
    public static void Sign_Up()
    {
        // login with user and password or create new user
        Clear();
        var typeOfUser = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select your type of user")
                .PageSize(3)
                .AddChoices(new[] {
                    gStoreKeeper, gTeacher, gStudent
        }));
        UserStatus status = UserStatus.UserNotFound;
        switch (typeOfUser)
        {
            case gStoreKeeper:
                status = UserFactory.CreateUser(UserFactory.StoreKeeper);
                break;
            case gTeacher:
                status = UserFactory.CreateUser(UserFactory.Teacher);
                break;
            case gStudent:
                status = UserFactory.CreateUser(UserFactory.Student);
                break;
        }

        Clear();
        switch(status)
        {
            case UserStatus.UserAlreadyExists:
                AnsiConsole.Markup("[red]User alredy exists[/]\n");
                break;
            case UserStatus.UserCreated:
                AnsiConsole.Markup("[green]User created successfully[/]\n");
                break;
            case UserStatus.UserNotFound:
                AnsiConsole.Markup("[red]User not found[/]\n");
                break;
        }
    }


    private static void CreateUserForm(string typeOfUser)
    {
        string password, confirmPassword, message, userName;
        do
        {
            Clear();
            AnsiConsole.Markup($"[blue]Sign Up[/] [grey]({typeOfUser})[/]\n");
            Write("Enter your user name: ");
            userName = ReadLine() ?? string.Empty;
            Write("Enter your password: ");
            password = ReadLine() ?? string.Empty;
            Write("Confirm your password: ");
            confirmPassword = ReadLine() ?? string.Empty;

            message = (password == confirmPassword) ? "[green]Passwords match[/]" : "[red]Passwords do not match[/]";
            AnsiConsole.Markup($"{message}\n[gray]Press any key to continue...[/]");
            ReadLine();
        } while (password != confirmPassword);
    }
    /*
    //Save user in Json file
    private static void SaveUser(string typeOfUser, string userName, string password)
    {
        string path = "Data/" + typeOfUser + ".json";
        //checks if Data/teachers.json exist
        if (!File.Exists(path))
        {
            //Create data folder
            Directory.CreateDirectory("Data");
            //Create Data/teachers.json
            File.Create(path).Dispose();
        }
        //Create new user
        switch (typeOfUser)
        {
            case gStoreKeeper:
                StoreKeeper storeKeeper = new();
                storeKeeper.CreateUser();
                break;
            case gTeacher:
                Teacher teacher = new();
                teacher.CreateUser();
                break;
            case gStudent:
                Student student = new();
                student.CreateUser();
                break;
        }
        Clear();
        AnsiConsole.Markup("[green]User created successfully[/]\n");
    }
    */
}