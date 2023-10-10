using System.ComponentModel.DataAnnotations;

namespace Almacen.Models
{
    [Serializable]
    public class Student : User
    {
        [Required]
        
        public List<string> classroms { get; set; }

        public Student()
        {
            Id = string.Empty;
            Name = string.Empty;
            LastName = string.Empty;
            SurName = string.Empty;
            classroms = new List<string>();
        }
    }
}