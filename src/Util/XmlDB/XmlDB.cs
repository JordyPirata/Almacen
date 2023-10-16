
using Almacen.Models;
using System.Xml.Serialization;

namespace Almacen.Util.XmlUser;

public class XmlDB : DB
{

    public string TypeOfUser { get; set; }
    public string Path { get; set; }

    public XmlDB(string typeOfUser)
    {
        TypeOfUser = typeOfUser;
        Path = CreateDB();
    }
    public override string CreateDB()
    {
        // Create directory if it does not exist
        const string directoryPath = "Data";

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        string filePath = Path = $"{directoryPath}/{TypeOfUser}.xml";
        return filePath;
    }
    public List<Teacher>? GetTeachers()
    {
        List<Teacher> teachers = new List<Teacher>();
        if (File.Exists(Path))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Teacher>));
            using (FileStream stream = File.OpenRead(Path))
            {
                teachers = (List<Teacher>)serializer.Deserialize(stream);
            }
        }
        return teachers ?? new List<Teacher>();
    }
    public List<Student>? GetStudents()
    {
        List<Student> students = new List<Student>();
        if (File.Exists(Path))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (FileStream stream = File.OpenRead(Path))
            {
                students = (List<Student>)serializer.Deserialize(stream);
            }
        }
        return students ?? new List<Student>();
    }
    public List<StoreKeeper>? GetStoreKeepers()
    {
        List<StoreKeeper> storeKeepers = new List<StoreKeeper>();
        if (File.Exists(Path))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<StoreKeeper>));
            using (FileStream stream = File.OpenRead(Path))
            {
                storeKeepers = (List<StoreKeeper>)serializer.Deserialize(stream);
            }
        }
        return storeKeepers ?? new List<StoreKeeper>();
    }
    public override void SaveUser(User user)
    {
        XmlSerializer serializer;
        switch (user)
        {
            case Teacher teacher:
                List<Teacher> teachers = GetTeachers() ?? new List<Teacher>();
                teachers.Add(teacher);
                serializer = new XmlSerializer(typeof(List<Teacher>));
                using (FileStream stream = File.Create(Path))
                {
                    serializer.Serialize(stream, teachers);
                }
                break;
            case Student student:
                List<Student> students = GetStudents() ?? new List<Student>();
                students.Add(student);
                serializer = new XmlSerializer(typeof(List<Student>));
                using (FileStream stream = File.Create(Path))
                {
                    serializer.Serialize(stream, students);
                }
                break;
            case StoreKeeper storeKeeper:
                List<StoreKeeper> storeKeepers = GetStoreKeepers() ?? new List<StoreKeeper>();
                storeKeepers.Add(storeKeeper);
                serializer = new XmlSerializer(typeof(List<StoreKeeper>));
                using (FileStream stream = File.Create(Path))
                {
                    serializer.Serialize(stream, storeKeepers);
                }
                break;
        }
    }
    public override bool HaveUser(string userName)
    {
        switch (TypeOfUser)
        {
            case UserFactory.Teacher:
                return GetTeachers().Any(teacher => teacher.UserName == userName);
            case UserFactory.Student:
                return GetStudents().Any(student => student.UserName == userName);
            case UserFactory.StoreKeeper:
                return GetStoreKeepers().Any(storeKeeper => storeKeeper.UserName == userName);
            default:
                throw new ArgumentException("Invalid user type", nameof(TypeOfUser));
        }
    }
}
