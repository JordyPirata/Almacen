using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almacen.Models;

namespace Almacen.Menu;

public class Menu
{
    public static void MainMenu(User user)
    {
        Clear();
        AnsiConsole.Markup($"[green]Welcome to Almacen[/] [grey]({user.UserName}: {user.TypeOfUser})[/]\n");
        AnsiConsole.Markup("[grey]Press any key to continue...[/]\n");
        ReadKey();
        switch (user)
        {
            case Teacher teacher:
                TeacherMenu(teacher);
                break;
            case Student student:
                StudentMenu(student);
                break;
            case StoreKeeper storeKeeper:
                StoreKeeperMenu(storeKeeper);
                break;
        }
    }
    private static void TeacherMenu(Teacher teacher)
    {
        WriteLine("Hello Teacher!");
    }
    private static void StudentMenu(Student student)
    {
        WriteLine("Hello Student!");
    }
    private static void StoreKeeperMenu(StoreKeeper storeKeeper)
    {
        WriteLine("Hello StoreKeeper!");
    }

}