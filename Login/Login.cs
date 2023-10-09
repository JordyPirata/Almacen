// Purpose: Login class for the Almacen program.
using System.Reflection.Metadata;
using Spectre.Console;

namespace Almacen.Login
{
    public class Login
    {
        //Console Login
        public static void ConsoleLogin()
        {
            // login with user and password or create new user
            const string? SignIn = "Sign In", SignUp  = "Sign Up";
            
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
                    //LoginUser();
                    break;
                case SignUp:
                    //CreateUser();
                    break;
            }
        }

        //Check if user exist in database
        /*
        static bool CheckUser(string user, string password, string? typeOfUser)
        {

        }
        */

    }
}