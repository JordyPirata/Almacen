using Almacen.Models;
namespace Almacen.Util;

public enum ReportType
{
    ReportByClassroom,
    ReportByPayroll,
    ReportBySubject,
    ReportById,
    ReportByUserName,

}
public abstract class DB
{
    public string TypeOfUser { get; set; }

    public DB(string typeOfUser)
    {
        TypeOfUser = typeOfUser;
    }
    public abstract void CreateDB();
    public abstract void SaveUser(User user);
    public abstract List<Teacher>? GetTeachers();
    public abstract List<Student>? GetStudents();
    public abstract List<StoreKeeper>? GetStoreKeepers();
    public bool HaveUser(string userName)
    {
        switch (TypeOfUser)
        {
            case UserFactory.Teacher:
                var teachers = GetTeachers() ?? new List<Teacher>();
                return teachers.Any(teacher => teacher.UserName == userName);
            case UserFactory.Student:
                var students = GetStudents() ?? new List<Student>();
                return students.Any(student => student.UserName == userName);
            case UserFactory.StoreKeeper:
                var storeKeepers = GetStoreKeepers() ?? new List<StoreKeeper>();
                return storeKeepers.Any(storeKeeper => storeKeeper.UserName == userName);
            default:
                throw new ArgumentException("Invalid user type", nameof(TypeOfUser));
        }
    }
    public User  GetUser(string userName)
    {
        switch (TypeOfUser)
        {
            case UserFactory.Teacher:
                List<Teacher> teachers = GetTeachers() ?? new List<Teacher>();
                return teachers.Find(user => user.UserName == userName);
            case UserFactory.Student:
                List<Student> students = GetStudents() ?? new List<Student>();
                return students.Find(user => user.UserName == userName);
            case UserFactory.StoreKeeper:
                List<StoreKeeper> storeKeepers = GetStoreKeepers() ?? new List<StoreKeeper>();
                return storeKeepers.Find(user => user.UserName == userName);
            default:
                throw new ArgumentException("Invalid user type", nameof(TypeOfUser));
        }
    }
    public abstract void DeleteUser(User user);
    //Test ssh key
}