using Almacen.Models;

namespace Almacen.Util
{
    public static class DBFactory
    {
        public const int JSON = 1;
        public const int XML = 2;
        public const int SQL = 3;
        public const int MONGO = 4;
        public const int MYSQL = 5;

        /*
        public static DB<User> GetDB(int type)
        {
            switch (type)
            {
                case JSON:
                    return new JsonDB<User>();
                case XML:
                    return new XmlDB<User>();
                case SQL:
                    return new SqlDB<User>();
                case MONGO:
                    return new MongoDB<User>();
                case MYSQL:
                    return new MySqlDB<User>();
                default:
                    return null;
            }
        }
        */
    }
}