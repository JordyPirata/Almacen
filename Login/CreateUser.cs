using Spectre.Console;
namespace Almacen.Login
{
    public class CreateUser
    {
        public CreateUser()
        {
            
        }

        public static void TypeOfUser()
        {
            Clear();
            var typeOfUser = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select your type of user")
                    .PageSize(3)
                    .AddChoices(new[] {
                        "Administrador", "Profesor", "Estudiante"
            }));
            switch (typeOfUser)
            {
                case "Administrador":
                    //CreateAdmin();
                    break;
                case "Profesor":
                    //CreateTeacher();
                    break;
                case "Estudiante":
                    //CreateStudent();
                    break;
            }
        }
    }
}