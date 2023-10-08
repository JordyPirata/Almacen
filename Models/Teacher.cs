namespace Almacen.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Class> Classes { get; set; }

        public Teacher()
        {
            Id = 0;
            Name = string.Empty;
            LastName = string.Empty;
        }

        public Teacher(int id, string name, string lastName)
        {
            Id = id;
            Name = name;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"Profesor: {Id} {Name} {LastName}";
        }
        
    }
}