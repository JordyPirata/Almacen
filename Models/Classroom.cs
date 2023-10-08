namespace Almacen.Models
{
    public class Classroom
    {
        public string Id { get; set; }

        public Classroom()
        {
            Id = string.Empty;
        }

        public override string ToString()
        {
            return $"classroom: {Id}";
        }
    }
}