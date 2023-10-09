using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Almacen.Models
{
    public class Teacher
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string FullName => $"{Name} {LastName} {SurName}";
        protected decimal Salary { get; set; }

        public Teacher()
        {
            Id = string.Empty;
            Name = string.Empty;
            LastName = string.Empty;
            SurName = string.Empty;
        }
    }
}