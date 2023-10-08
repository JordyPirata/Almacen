namespace Almacen.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<string> Classes { get; set; }

        public Student()
        {
            Id = 0;
            Name = string.Empty;
            Classes = new List<string>();
        }

        public override string ToString()
        {
            return $"Estudiante: {Id} {Name}\n{string.Join(",", Classes)}";
        }
    }
}