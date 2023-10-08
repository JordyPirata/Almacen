namespace Almacen.Models
{
    public class Teacher
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public List<Class> Classes { get; set; }
        public Teacher()
        {
            Id = string.Empty;
            Name = string.Empty;
            LastName = string.Empty;
            Classes = new List<Class>();
        }
        public Teacher(string id, string name, string lastName)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Classes = new List<Class>();
        }

        public override string ToString()
        {
            return $"Teacher: {Id} {Name} {LastName}";
        }
        
    }
}