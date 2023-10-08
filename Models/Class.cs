namespace Almacen.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public Teacher Teacher { get; set; }

        public Class()
        {
            Id = 0;
            Name = string.Empty;
            Teacher = new Teacher();
        }

        public override string ToString()
        {
            return $"Clase: {Id} {Name} {Teacher}";
        }
    }
}