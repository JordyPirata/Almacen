// See https://aka.ms/new-console-template for more information
using Almacen.Login;
using Almacen.Models;
using Almacen.Menu;
User? user;
do
{
    user = Login.ConsoleLogin();
    if (user != null)
    {
        Menu.MainMenu(user);
    }
} while (true);


