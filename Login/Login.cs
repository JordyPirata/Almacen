// Purpose: Login class for the Almacen program.
using System.Reflection.Metadata;
using Spectre.Console;
using Almacen.Helpers;

namespace Almacen.Login
{
    public class Login
    {
        //Console Login
        public static void ConsoleLogin()
        {
            // login with user and password or create new user
            const string? SignIn = "Sign In", SignUp = "Sign Up";

            Clear();
            var user = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select an option")
                    .PageSize(3)
                    .AddChoices(new[] {
                        SignIn, SignUp
            }));
            switch (user)
            {
                case SignIn:

                    LoginUser.SingIn();
                    break;
                case SignUp:
                    LoginUser.SignUp();
                    break;
            }
        }
    }
}