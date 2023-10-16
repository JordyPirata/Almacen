using Almacen.Models;

namespace Almacen.Util.JsonUser;

public class JsonDB : DB
{
    public string TypeOfUser { get; set; }
    public string Path { get; set; }
    public JsonDB(string typeOfUser)
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

        // Create file if it does not exist
        string filePath = Path = $"{directoryPath}/{TypeOfUser}.json";
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }

        return filePath;
    }
    public List<Teacher>? GetTeachers()
    {
        List<Teacher> teachers = new List<Teacher>();
        if (File.Exists(Path))
        {
            string json = File.ReadAllText(Path);
            teachers = JsonConvert.DeserializeObject<List<Teacher>>(json);
        }
        return teachers ?? new List<Teacher>();
    }
    public List<Student>? GetStudents()
    {
        List<Student> students = new List<Student>();
        if (File.Exists(Path))
        {
            string json = File.ReadAllText(Path);
            students = JsonConvert.DeserializeObject<List<Student>>(json);
        }
        return students ?? new List<Student>();
    }
    public List<StoreKeeper>? GetStoreKeepers()
    {
        List<StoreKeeper> storeKeepers = new List<StoreKeeper>();
        if (File.Exists(Path))
        {
            string json = File.ReadAllText(Path);
            storeKeepers = JsonConvert.DeserializeObject<List<StoreKeeper>>(json);
        }
        return storeKeepers ?? new List<StoreKeeper>();
    }
    public override void SaveUser(User user)
    {
        switch (user)
        {
            case Teacher teacher:
                List<Teacher> teachers = GetTeachers() ?? new List<Teacher>();
                teachers.Add(teacher);
                string jsonTeachers = JsonConvert.SerializeObject(teachers);
                File.WriteAllText(Path, jsonTeachers);
                break;
            case Student student:
                List<Student> students = GetStudents() ?? new List<Student>();
                students.Add(student);
                string jsonStudents = JsonConvert.SerializeObject(students);
                File.WriteAllText(Path, jsonStudents);
                break;
            case StoreKeeper storeKeeper:
                List<StoreKeeper> storeKeepers = GetStoreKeepers() ?? new List<StoreKeeper>();
                storeKeepers.Add(storeKeeper);
                string jsonStoreKeepers = JsonConvert.SerializeObject(storeKeepers);
                File.WriteAllText(Path, jsonStoreKeepers);
                break;
            default:
                throw new ArgumentException("Invalid user type", nameof(user));
        }
    }
    public override bool HaveUser(string userName)
    {
        switch (TypeOfUser)
        {
            case UserFactory.Teacher:
                List<Teacher> teachers = GetTeachers() ?? new List<Teacher>();
                return teachers.Any(user => user.UserName == userName);
            case UserFactory.Student:
                List<Student> students = GetStudents() ?? new List<Student>();
                return students.Any(user => user.UserName == userName);
            case UserFactory.StoreKeeper:
                List<StoreKeeper> storeKeepers = GetStoreKeepers() ?? new List<StoreKeeper>();
                return storeKeepers.Any(user => user.UserName == userName);
            default:
                throw new ArgumentException("Invalid user type", nameof(TypeOfUser));
        }
    }
}