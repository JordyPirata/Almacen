using Spectre.Console;
using Almacen.Models;
using System.Xml.Serialization; // XmlSerializer
using static System.Environment;
using static System.IO.Path;

namespace Almacen.Login
{
    public class LoginUser
    {
        //Check if user exist in Data/ users.json
        public static void SingIn()
        {
            AnsiConsole.Markup("[blue]Sign In[/]\n");
            Write("Enter your user name: ");
            var userName = ReadLine();
            Write("Enter your password: ");
            var password = ReadLine();

            string path = "Data/Users.json";
            string json = File.ReadAllText(path);
            WriteLine(password);
            WriteLine();
            WriteLine(json);
            //Check if user exist in database

        }
        public static void SignUp()
        {
            const string admin = "Admin", teacher = "Teacher", student = "Student";
            Clear();
            var typeOfUser = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select your type of user")
                    .PageSize(3)
                    .AddChoices(new[] {
                        admin, teacher, student
            }));
            switch (typeOfUser)
            {
                case admin:
                    CreateUser(admin);
                    break;
                case teacher:
                    CreateUser(teacher);
                    break;
                case student:
                    CreateUser(student);
                    break;
            }
        }
        private static void CreateUser(string typeOfUser)
        {
            AnsiConsole.Markup("[blue]Sign Up[/]\n");
            Write("Enter your user name: ");
            var userName = ReadLine();
            Write("Enter your password: ");
            var password = ReadLine();
            Write("Confirm your password: ");
            var confirmPassword = ReadLine();
            if (password == confirmPassword)
            {
                string path = "Data/Users.json";
                //Create new teacher
                Teacher teacher = new Teacher();
                teacher.SetUser(userName, password);
                //checks if Data/tachers.json exist
                if (!File.Exists(path))
                {
                    //Create Data/teachers.json
                    File.Create(path);
                }

                //Save teacher in database
                //string json = JsonConverter(teacher);
                AnsiConsole.Markup("[green]User created successfully[/]\n");
            }
            else
            {
                AnsiConsole.Markup("[red]Passwords do not match[/]\n");
            }
        }
    }
}