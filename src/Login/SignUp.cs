using System.Text.Json;
using System.Text.Json.Nodes;
using Almacen.Models;

namespace Almacen.Login;
public class SignUp
{
    public const string gStoreKeeper = "StoreKeeper", gTeacher = "Teacher", gStudent = "Student";
    //Console Sign Up
    public static void Sign_Up()
    {

        Clear();
        var typeOfUser = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select your type of user")
                .PageSize(3)
                .AddChoices(new[] {
                    gStoreKeeper, gTeacher, gStudent
        }));
        switch (typeOfUser)
        {
            case gStoreKeeper:
                CreateUserForm(gStoreKeeper);
                break;
            case gTeacher:
                CreateUserForm(gTeacher);
                break;
            case gStudent:
                CreateUserForm(gStudent);
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
        
        SaveUser(typeOfUser, userName, password);
    }

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
        Dictionary<string, string> users = new();

        string newUser = string.Empty;
        switch (typeOfUser)
        {
            case gStoreKeeper:
                StoreKeeper storeKeeper = new();
                storeKeeper.SetUser(userName, password);
                newUser = JsonSerializer.Serialize(storeKeeper);
                break;
            case gTeacher:
                Teacher teacher = new();
                teacher.SetUser(userName, password);
                newUser = JsonSerializer.Serialize(teacher);
                break;
            case gStudent:
                Student student = new();
                student.SetUser(userName, password);
                newUser = JsonSerializer.Serialize(student);
                break;
        }
        //read Data/{typeOfUser}.json
        if (File.Exists(path)) {
            using var jsonLoad = File.Open(path, FileMode.Open);
            var json = JsonNode.Parse(jsonLoad);

        }



        //Add user in a dictionary of users
        // Dictionary<string, string> users = new();
        users.Add(userName, newUser);
        //Serialize dictionary
        //string usersJson = System.Text.Json.JsonSerializer.Serialize(users);
        //Save in Data/teachers.json
        // File.WriteAllText(path, usersJson);
        Clear();
        AnsiConsole.Markup("[green]User created successfully[/]\n");
    }
}