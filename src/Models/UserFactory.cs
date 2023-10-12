namespace Almacen.Models;

public class UserFactory
{
    public const string Teacher = "Teacher";
    public const string Student = "Student";
    public const string StoreKeeper = "StoreKeeper";

    public static UserStatus CreateUser(string userType)
    {
        UserStatus status;
        switch (userType)
        {
            case Teacher:
                new Teacher();
                status = UserStatus.UserCreated;
                break;
            case Student:
                new Student();
                status = UserStatus.UserCreated;
                break;
            case StoreKeeper:
                new StoreKeeper();
                status = UserStatus.UserCreated;
                break;
            default:
                status = UserStatus.UserNotFound;
                break;
        }
        return status;
    }
}
