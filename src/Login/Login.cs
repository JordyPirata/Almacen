// Purpose: Login class for the Almacen program.

namespace Almacen.Login;

public class Login
{
    public const string singIn = "Sign In", signUp = "Sign Up";
    public const string gStoreKeeper = "StoreKeeper", gTeacher = "Teacher", gStudent = "Student";
    public static string SelectUser()
    {
        Clear();
        var typeOfUser = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select your type of user")
                .PageSize(3)
                .AddChoices(new[] {
                    gStoreKeeper, gTeacher, gStudent
        }));
        return typeOfUser;
    }
    //Console Login
    public static void ConsoleLogin()
    {
        // login with user and password or create new user
        Clear();
        var user = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option")
                .PageSize(3)
                .AddChoices(new[] {
                    singIn, signUp
        }));
        switch (user)
        {
            case singIn:
                SignIn.Sign_In();
                break;
            case signUp:
                SignUp.Sign_Up();
                break;
        }
    }
}