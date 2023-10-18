namespace Almacen.Models;
public struct UserData
{

}
public class UserFactory
{
    public const string Teacher = "Teacher";
    public const string Student = "Student";
    public const string StoreKeeper = "StoreKeeper";

    public static User CreateUser(string userType, string userName, string password)
    {
        User user;
        switch (userType)
        {
            case Teacher:
                user = new Teacher(userName, password);
                break;
            case Student:
                user = new Student(userName, password);
                break;
            case StoreKeeper:
                user = new StoreKeeper(userName, password);
                break;
            default:
                throw new ArgumentException("Invalid user type", nameof(userType));
        }
        return user;
    }

}
