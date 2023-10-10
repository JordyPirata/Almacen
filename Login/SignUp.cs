using Almacen.Models;

namespace Almacen.Login
{

    public class SignUp
    {
        public const string gAdmin = "Admin", gTeacher = "Teacher", gStudent = "Student";
        //Console Sign Up
        public static void Sign_Up()
        {

            Clear();
            var typeOfUser = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select your type of user")
                    .PageSize(3)
                    .AddChoices(new[] {
                        gAdmin, gTeacher, gStudent
            }));
            switch (typeOfUser)
            {
                case gAdmin:
                    CreateUser(gAdmin);
                    break;
                case gTeacher:
                    CreateUser(gTeacher);
                    break;
                case gStudent:
                    CreateUser(gStudent);
                    break;
            }
        }
        private static void CreateUser(string typeOfUser)
        {
            string password, confirmPassword, message,userName;
            do
            {
                Clear();
                AnsiConsole.Markup($"[blue]Sign Up[/][grey] ({typeOfUser})[/]\n");
                Write("Enter your user name: ");
                userName = ReadLine() ?? string.Empty;
                Write("Enter your password: ");
                password = ReadLine() ?? string.Empty;
                Write("Confirm your password: ");
                confirmPassword = ReadLine() ?? string.Empty;

                message = (password == confirmPassword) ? "[green]Passwords match[/]" : "[red]Passwords do not match[/]";
                AnsiConsole.Markup($"{message}\n[gray]Press any key to continue...[/]");
                ReadLine();
            } while (password != confirmPassword);

            SaveUserJson(typeOfUser, userName, password);
        }

        //Save user in Json file
        private static void SaveUserJson(string typeOfUser, string userName, string password)
        {
            string path = "Data/" + typeOfUser + ".json";
            //checks if Data/teachers.json exist
            if (!File.Exists(path))
            {
                //Create data folder
                Directory.CreateDirectory("Data");
                //Create Data/teachers.json
                File.Create(path).Dispose();
            }
            //Create new user

            string json = string.Empty;
            switch (typeOfUser)
            {
                case gAdmin:
                    //Admin admin = new();
                    //admin.SetUser(userName, password);
                    //json = System.Text.Json.JsonSerializer.Serialize(admin);
                    break;
                case gTeacher:
                    Teacher teacher = new();
                    teacher.SetUser(userName, password);
                    json = System.Text.Json.JsonSerializer.Serialize(teacher);
                    break;
                case gStudent:
                    Student student = new();
                    student.SetUser(userName, password);
                    json = System.Text.Json.JsonSerializer.Serialize(student);
                    break;
            }
            //Save teacher in database
            File.WriteAllText(path, json);
            AnsiConsole.Markup("[green]User created successfully[/]\n");
        }
    }
}