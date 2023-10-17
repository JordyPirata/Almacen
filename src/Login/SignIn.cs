using Almacen.Util;
using Almacen.Helpers;
namespace Almacen.Login;

public class SignIn : Login
{
    public static void Sign_In()
    {
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
            
            if(!(VerificateUser(userName, password, dbJson) || VerificateUser(userName, password, dbXml)))
            {
                Clear();
                AnsiConsole.Markup("[red]User or password incorrect[/]\n");
                AnsiConsole.Markup("[red]Press any key to continue...[/]\n");
                ReadKey();
            }
            
        }while(!(VerificateUser(userName, password, dbJson) || VerificateUser(userName, password, dbXml)));

        Clear();
        AnsiConsole.Markup($"[green]Welcome to Almacen[/] [grey]({userName}: {typeOfUser})[/]\n");
        AnsiConsole.Markup("[grey]Press any key to continue...[/]\n");
        ReadKey();
        
    }
    public static bool VerificateUser(string userName, string password, DB db) => 
    
    db.HaveUser(userName) && Md5Encryption.VerifyMd5Hash(password, db.getUser(userName).Password);


}
