using Almacen.Models;

namespace Almacen.Util.JsonUser;

public class JsonDB : DB
{
    public string Path { get; set; }
    public JsonDB(string typeOfUser) : base(typeOfUser)
    {
        TypeOfUser = typeOfUser;
        Path = $"Data/{TypeOfUser}.json";
        CreateDB();
    }
    public override void CreateDB()
    {
        // Create directory if it does not exist

        if (!Directory.Exists("Data"))
        {
            Directory.CreateDirectory("Data");
        }
        // Create file if it does not exist
        if (!File.Exists(Path))
        {
            File.Create(Path).Close();
        }
    }
    public override List<Teacher>? GetTeachers()
    {
        List<Teacher> teachers = new List<Teacher>();
        if (File.Exists(Path))
        {
            string json = File.ReadAllText(Path);
            teachers = JsonConvert.DeserializeObject<List<Teacher>>(json);
        }
        return teachers ?? new List<Teacher>();
    }
    public override List<Student>? GetStudents()
    {
        List<Student> students = new List<Student>();
        if (File.Exists(Path))
        {
            string json = File.ReadAllText(Path);
            students = JsonConvert.DeserializeObject<List<Student>>(json);
        }
        return students ?? new List<Student>();
    }
    public override List<StoreKeeper>? GetStoreKeepers()
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
    public override void DeleteUser(User user)
    {
        int index;
        switch (user)
        {
            case Teacher teacher:
                List<Teacher> teachers = GetTeachers() ?? new List<Teacher>();
                // find index of desired teacher to delete
                index = teachers.FindIndex(t => t.Id == teacher.Id);
                teachers.RemoveAt(index);
                string jsonTeachers = JsonConvert.SerializeObject(teachers);
                File.WriteAllText(Path, jsonTeachers);
                break;
            case Student student:
                List<Student> students = GetStudents() ?? new List<Student>();
                // find index of desired student to delete
                index = students.FindIndex(s => s.Id == student.Id);
                students.RemoveAt(index);
                string jsonStudents = JsonConvert.SerializeObject(students);
                File.WriteAllText(Path, jsonStudents);
                break;
            case StoreKeeper storeKeeper:
                List<StoreKeeper> storeKeepers = GetStoreKeepers() ?? new List<StoreKeeper>();
                // find index of desired store keeper to delete
                index = storeKeepers.FindIndex(s => s.Id == storeKeeper.Id);
                storeKeepers.RemoveAt(index);
                string jsonStoreKeepers = JsonConvert.SerializeObject(storeKeepers);
                File.WriteAllText(Path, jsonStoreKeepers);
                break;
            default:
                throw new ArgumentException("Invalid user type", nameof(user));
        }
    }
}