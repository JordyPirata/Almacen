using Almacen.Models;
using Almacen.Helpers;
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
    public List<Teacher> GenerateReport(ReportType type)
    {
        List<Teacher> teachers = GetTeachers() ?? new List<Teacher>();
        new CustomComparer();
        switch(type)
        {
            case ReportType.ReportByClassroom:
                //Sort classrooms
                teachers.ForEach(teacher => teacher.Classes.Sort((x,y) => new CustomComparer().Compare(x, y)));
                //Sort teachers by first classroom
                teachers.Sort((x,y) => new CustomComparer().Compare(x.Classes[0], y.Classes[0]));
                break;
            case ReportType.ReportByPayroll:
                teachers.Sort((x, y) => new CustomComparer().Compare(x.Payroll, y.Payroll));
                break;
            case ReportType.ReportBySubject:
                //Sort subjects
                teachers.ForEach(teacher => teacher.Subjects.Sort((x,y) => new CustomComparer().Compare(x, y)));
                //Sort teachers by first subject
                teachers.Sort((x, y) => new CustomComparer().Compare(x.Subjects[0], y.Subjects[0]));
                break;
            case ReportType.ReportById:
                teachers.Sort((x, y) => x.Id.CompareTo(y.Id));
                break;
            case ReportType.ReportByUserName:
                teachers.Sort((x, y) => new CustomComparer().Compare(x.UserName, y.UserName));
                break;
            default:
                throw new ArgumentException("Invalid report type", nameof(type));
        }
        return teachers;
    }
}