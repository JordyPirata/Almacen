using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Almacen.Models
{
    [Serializable]
    public class Teacher : User
    {
        [JsonInclude]
        public string Salary { get; set; }
        public Teacher(string userName, string password) : base(userName, password)
        {
            Salary = string.Empty;
        }

        public Teacher() : base()
        {
            Salary = string.Empty;

        }

    }
}