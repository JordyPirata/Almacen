using System.ComponentModel.DataAnnotations;

namespace Almacen.Models;

[Serializable]
public class Class
{
    [Required]
    public string Id { get; set; }
    [Required]
    public List<Student> Students { get; set; }
    public string Name { get; set; }

    public Class()
    {
        Id = string.Empty;
        Students = new List<Student>();
        Name = string.Empty;
    }
}