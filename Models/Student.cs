using System.ComponentModel.DataAnnotations;

namespace Almacen.Models
{
    [Serializable]
    public class Student : User
    {
        [Required]
        public string StudentId { get; set; }
        public string? Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string FullName => $"{Name} {LastName} {SurName}";
        public List<string> classroms { get; set; }

        public Student()
        {
            StudentId = string.Empty;
            Name = string.Empty;
            LastName = string.Empty;
            SurName = string.Empty;
            classroms = new List<string>();
        }
    }
}