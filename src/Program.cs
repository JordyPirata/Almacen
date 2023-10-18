// See https://aka.ms/new-console-template for more information
using Almacen.Login;
using Almacen.Models;
using Almacen.Menu;
User? user;

user = Login.ConsoleLogin();
if (user != null)
{
    Menu.MainMenu(user);
}

