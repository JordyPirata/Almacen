using System.ComponentModel.DataAnnotations;

namespace Almacen.Models;

[Serializable]
public class Student : User
{
    [Required]
    
    public List<string> classroms { get; set; }

    public Student()
    {
        classroms = new List<string>();
    }
}