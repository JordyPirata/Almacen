using Almacen.Models;
namespace Almacen.Util;

public abstract class DB
{

    public abstract string CreateDB();
    public abstract void SaveUser(User user);
    public abstract bool HaveUser(string userName);
}