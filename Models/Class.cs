namespace Almacen.Models
{
    public class Class
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public Teacher Teacher { get; set; }
        public Classroom Classroom { get; set; }
        public List<string> Students { get; set; }

        public Class()
        {
            Id = string.Empty;
            Name = string.Empty;
            Classroom = new Classroom();
            Teacher = new Teacher();
            Students = new List<string>();
        }

        public override string ToString()
        {
            return $"Clase: {Id}\n{Name}\n{Classroom}\n{Teacher}\nStudents:\n{string.Join(" ", Students)}";
        }
    }
}