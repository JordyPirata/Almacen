// Purpose: Login class for the Almacen program.

namespace Almacen.Login;

public class Login
{
    //Console Login
    public static void ConsoleLogin()
    {
        // login with user and password or create new user
        const string? signIn = "Sign In", signUp = "Sign Up";

        Clear();
        var user = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option")
                .PageSize(3)
                .AddChoices(new[] {
                    signIn, signUp
        }));
        switch (user)
        {
            case signIn:
                SingIn.Sing_In();
                break;
            case signUp:
                SignUp.Sign_Up();
                break;
        }
    }
}