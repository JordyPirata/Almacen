using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Almacen.Models
{
    [Serializable]
    public class Teacher : User
    {
        [JsonInclude]
        public string Salary { get; set; }
        [JsonInclude]
        public string Payroll { get; set; }
        [JsonInclude]
        public List<string> Subjects { get; set; }
        public List<string> Classes { get; set; }
        public Teacher(string userName, string password) : base(userName, password)
        {
            Salary = string.Empty;
            Payroll = string.Empty;
            Subjects = new List<string>();
            Classes = new List<string>();
            TypeOfUser = UserFactory.Teacher;
        }
        public Teacher() : base()
        {
            Salary = string.Empty;
            Payroll = string.Empty;
            Subjects = new List<string>();
            Classes = new List<string>();
            TypeOfUser = UserFactory.Teacher;
        }
        public string GetPayroll()
        {
            return Payroll;
        }
        public void SetPayroll(string payroll)
        {
            Payroll = payroll;
        }
        // override to string
        public override string ToString()
        {
            return base.ToString() +
                "Salary: " + Salary + "\n" +
                "Payroll: " + Payroll + "\n" +
                "Subjects: " + Subjects + "\n" +
                "Classes: " + Classes + "\n";
        }
    }
}