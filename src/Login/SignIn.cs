using Almacen.Util;
using Almacen.Helpers;
using Almacen.Models;
namespace Almacen.Login;

public class SignIn : Login
{
    public static User Sign_In()
    {
        AnsiConsole.Markup("[blue]Sign In[/]\n");
        string typeOfUser = SelectUser(), userName, password;
        //create database on json
        DB dbJson = DBFactory.CreateDB(DBFactory.JSON, typeOfUser);
        //create database on xml
        DB dbXml = DBFactory.CreateDB(DBFactory.XML, typeOfUser);
        do
        {
            Clear();
            AnsiConsole.Markup("[blue]Sign In[/]\n");
            Write("Enter your user name: ");
            userName = ReadLine() ?? string.Empty;
            Write("Enter your password: ");
            password = ReadLine() ?? string.Empty;

            if (!(VerificateUser(userName, password, dbJson) || VerificateUser(userName, password, dbXml)))
            {
                Clear();
                AnsiConsole.Markup("[red]User or password incorrect[/]\n");
                AnsiConsole.Markup("[red]Press any key to continue...[/]\n");
                ReadLine();
                Environment.Exit(0);
            }

        } while (!(VerificateUser(userName, password, dbJson) || VerificateUser(userName, password, dbXml)));
        return dbJson.GetUser(userName) ?? dbXml.GetUser(userName);
    }
    public static bool VerificateUser(string userName, string password, DB db) =>

    db.HaveUser(userName) && Md5Encryption.VerifyMd5Hash(password, db.GetUser(userName).Password);
}
