using System.ComponentModel.DataAnnotations;

namespace Almacen.Models
{
    [Serializable]
    public class Teacher : User
    {
        [Required]
        protected decimal Salary { get; set; }

        public Teacher()
        {
            Salary = 0;
        }
    }
}