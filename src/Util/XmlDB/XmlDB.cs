
using Almacen.Models;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Almacen.Util.XmlUser;

public class XmlDB : DB
{
    public string Path { get; set; }
    public XmlDB(string typeOfUser) : base(typeOfUser)
    {
        TypeOfUser = typeOfUser;
        Path = $"Data/{TypeOfUser}.xml";
        CreateDB();
    }
    public override void CreateDB()
    {
        // Create directory if it does not exist
        if (!Directory.Exists("Data"))
        {
            Directory.CreateDirectory("Data");
        }
    }
    public override List<Teacher>? GetTeachers()
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
    public override List<Student>? GetStudents()
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
    public override List<StoreKeeper>? GetStoreKeepers()
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
    public override void DeleteUser(User user)
    {
        XmlSerializer serializer;
        int index;
        switch (user)
        {
            case Teacher teacher:
                List<Teacher> teachers = GetTeachers() ?? new List<Teacher>();
                index = teachers.FindIndex(t => t.Id == teacher.Id);
                teachers.RemoveAt(index);
                serializer = new XmlSerializer(typeof(List<Teacher>));
                using (FileStream stream = File.Create(Path))
                {
                    serializer.Serialize(stream, teachers);
                }
                break;
            case Student student:
                List<Student> students = GetStudents() ?? new List<Student>();
                index = students.FindIndex(s => s.Id == student.Id);
                students.RemoveAt(index);
                serializer = new XmlSerializer(typeof(List<Student>));
                using (FileStream stream = File.Create(Path))
                {
                    serializer.Serialize(stream, students);
                }
                break;
            case StoreKeeper storeKeeper:
                List<StoreKeeper> storeKeepers = GetStoreKeepers() ?? new List<StoreKeeper>();
                index = storeKeepers.FindIndex(s => s.Id == storeKeeper.Id);
                storeKeepers.RemoveAt(index);
                serializer = new XmlSerializer(typeof(List<StoreKeeper>));
                using (FileStream stream = File.Create(Path))
                {
                    serializer.Serialize(stream, storeKeepers);
                }
                break;
        }
    }
}