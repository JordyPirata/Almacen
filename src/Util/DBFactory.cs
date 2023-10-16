using Almacen.Models;
using Almacen.Util.JsonUser;
using Almacen.Util.XmlUser;
namespace Almacen.Util;


public static class DBFactory
{
    public const int JSON = 1;
    public const int XML = 2;
    public const int SQL = 3;
    public const int MONGO = 4;
    public const int MYSQL = 5;
    //create DB
    public static DB CreateDB(int typeOfDB, string typeOfUser)
    {
        return typeOfDB switch
        {
            JSON => new JsonDB(typeOfUser),
            XML => new XmlDB(typeOfUser),
            _ => throw new ArgumentException("Invalid type of DB")
        };
    }
}