using System.ComponentModel.DataAnnotations;
namespace Almacen.Models;

[Serializable]
public class Student : User
{
    public List<string> classroms { get; set; }
    public Student(string userName, string password) : base(userName, password)
    {
        classroms = new List<string>();
    }
    public Student() : base()
    {
        classroms = new List<string>();
    }
}