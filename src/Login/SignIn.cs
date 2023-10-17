using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almacen.Util;

namespace Almacen.Login;

public class SignIn : Login
{
    public static void Sign_In()
    {
        var typeOfUser = SelectUser();
        //create database on json
        DB dbJson = DBFactory.CreateDB(DBFactory.JSON, typeOfUser);
        //create database on xml
        DB dbXml = DBFactory.CreateDB(DBFactory.XML, typeOfUser);
        Clear();
        AnsiConsole.Markup("[blue]Sign In[/]\n");
        Write("Enter your user name: ");
        var userName = ReadLine();
        Write("Enter your password: ");
        var password = ReadLine();

        //check if user exists



    }

    public static bool VerificateUser(string userName, string password, DB db)
    {
        db.HaveUser(userName);

        return false;
    }
}