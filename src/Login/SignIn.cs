using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Login;

public class SignIn 
{
    public static void Sign_In()
    {
        Clear();
        AnsiConsole.Markup("[blue]Sign In[/]\n");
        Write("Enter your user name: ");
        var userName = ReadLine();
        Write("Enter your password: ");
        var password = ReadLine();
        //Check if user exist in database
        

    }
}