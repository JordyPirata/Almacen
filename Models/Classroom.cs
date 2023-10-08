namespace Almacen.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string ClassroomName { get; set; }
        public List<Student> Students { get; set; }

        public Classroom()
        {
            Id = 0;
            ClassroomNameName = string.Empty;
            Students = new List<Student>();
        }

        public override string ToString()
        {
            return $"Aula: {Id} {ClassroomNameName} {Students}";
        }
    }
}