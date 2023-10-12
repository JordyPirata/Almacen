using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Login;

public class SingIn
{
    public static void Sing_In()
    {
        AnsiConsole.Markup("[blue]Sign In[/]\n");
        Write("Enter your user name: ");
        var userName = ReadLine();
        Write("Enter your password: ");
        var password = ReadLine();

        string path = "Data/Users.json";
        string json = File.ReadAllText(path);
        WriteLine(password);
        WriteLine();
        WriteLine(json);
        //Check if user exist in database

    }
}