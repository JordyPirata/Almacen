using System.ComponentModel.DataAnnotations;

namespace Almacen.Models;

[Serializable]
public class Class
{
    [Required]
    public string Id { get; set; }
    [Required]
    public List<Student> Students { get; set; }
    [Required]
    public Teacher Teacher { get; set; }
    public List<string> classroms { get; set; }

    public Class()
    {
        Id = string.Empty;
        Students = new List<Student>();
        Teacher = new Teacher(string.Empty, string.Empty);
        classroms = new List<string>();
    }
}