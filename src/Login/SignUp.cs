using Almacen.Models;
using Almacen.Util;

namespace Almacen.Login;
public class SignUp : Login
{
    //Console Sign Up
    public static void Sign_Up()
    {
        // login with user and password or create new user
        AnsiConsole.Markup("[blue]Sign Up[/]\n");
        var typeOfUser = SelectUser();
        switch (typeOfUser)
        {
            case gStoreKeeper:
                CreateUserForm(UserFactory.StoreKeeper);
                break;
            case gTeacher:
                CreateUserForm(UserFactory.Teacher);
                break;
            case gStudent:
                CreateUserForm(UserFactory.Student);
                break;
        }
    }
    private static void CreateUserForm(string typeOfUser)
    {
        Clear();
        string password, confirmPassword, message, userName;
        //create database on json
        DB dbJson = DBFactory.CreateDB(DBFactory.JSON, typeOfUser);
        //create database on xml
        DB dbXml = DBFactory.CreateDB(DBFactory.XML, typeOfUser);
        do
        {
            AnsiConsole.Markup($"[blue]Sign Up[/] [grey]({typeOfUser})[/]\n");
            Write("Enter your user name: ");
            userName = ReadLine() ?? string.Empty;
            Write("Enter your password: ");
            password = ReadLine() ?? string.Empty;
            Write("Confirm your password: ");
            confirmPassword = ReadLine() ?? string.Empty;

            //Check if passwords match
            Clear();
            message = (password == confirmPassword) ? "[green]Passwords match[/]\n" : "[red]Passwords do not match[/]\n";
            if (dbJson.HaveUser(userName) || dbJson.HaveUser(userName))
            {
                message = "[red]User already exists[/]\n";
            }
            AnsiConsole.Markup($"{message}");
            //Check if user exist in database
        } while (password != confirmPassword || dbJson.HaveUser(userName) || dbJson.HaveUser(userName));

        //Save user
        dbJson.SaveUser(UserFactory.CreateUser(typeOfUser, userName, password));
        dbXml.SaveUser(UserFactory.CreateUser(typeOfUser, userName, password));
        Clear();

        message = "[green]User created successfully[/]";
        AnsiConsole.Markup($"{message}\n[gray]Press any key to continue...[/]");
        ReadLine();

        SignIn.Sign_In();
    }
}