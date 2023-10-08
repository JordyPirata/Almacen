namespace Almacen.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Class> classes { get; set; }

        public Student()
        {
            Id = 0;
            Name = string.Empty;
            Class = new Class();
        }

        public override string ToString()
        {
            return $"Estudiante: {Id} {Name} {Class}";
        }
    }
}