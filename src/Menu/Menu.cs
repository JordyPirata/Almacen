using System.IO.Compression;
using System.Runtime.CompilerServices;
using Almacen.Models;
using Almacen.Util;

namespace Almacen.Menu;

public class Menu
{
    const string gStoreKeeper = "StoreKeeper", gTeacher = "Teacher", gStudent = "Student";
    const string generateReport = "Generate Report", deleteUser = "deleteUser", exit = "Exit";
    public static void MainMenu(User user)
    {
        Clear();
        AnsiConsole.Markup($"[green]Welcome to Almacen[/] [grey]({user.UserName}: {user.TypeOfUser})[/]\n");
        AnsiConsole.Markup("[grey]Press any key to continue...[/]\n");
        ReadKey();
        switch (user)
        {
            case Teacher teacher:
                TeacherMenu(teacher);
                break;
            case Student student:
                StudentMenu(student);
                break;
            case StoreKeeper storeKeeper:
                StoreKeeperMenu(storeKeeper);
                break;
        }
    }
    private static void TeacherMenu(Teacher teacher)
    {
        WriteLine("Hello Teacher");
    }
    private static void StudentMenu(Student student)
    {
        WriteLine("Hello Student!");
    }
    private static void StoreKeeperMenu(StoreKeeper storeKeeper)
    {
        Clear();
        AnsiConsole.Markup($"[green]Welcome to Almacen[/] [grey]({storeKeeper.UserName}: {storeKeeper.TypeOfUser})[/]\n");
        var menu = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Teacher Menu:")
            .PageSize(5)
            .AddChoices(new[] {
                generateReport, deleteUser, exit
        }));
        switch (menu)
        {
            case generateReport:
                GenerateReportMenu(storeKeeper);
                break;
            case deleteUser:
                DeleteUserMenu(storeKeeper);
                break;
            case exit:
                Environment.Exit(0);
                break;
        }

    }
    private static void DeleteUserMenu(StoreKeeper storeKeeper)
    {
        Clear();
        AnsiConsole.Markup($"[green]Welcome to Almacen[/] [grey]({storeKeeper.UserName}: {storeKeeper.TypeOfUser})[/]\n");
        DB dbJson = DBFactory.CreateDB(DBFactory.JSON, gStoreKeeper);
        DB dbXml = DBFactory.CreateDB(DBFactory.XML, gStoreKeeper);
        var menu = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What type of user you want to delete?:")
            .PageSize(5)
            .AddChoices(new[] {
                gStoreKeeper, gTeacher, gStudent, exit
        }));
        switch (menu)
        {
            case gStoreKeeper:
                DeleteStoreKeeperMenu(dbJson, dbXml);
                break;
            case gTeacher:
                DeleteTeacherMenu(dbJson, dbXml);
                break;
            case gStudent:
                DeleteStudentMenu(dbJson, dbXml);
                break;
            case exit:
                Environment.Exit(0);
                break;
        }
    }

    private static void DeleteStudentMenu(DB dbJson, DB dbXml)
    {
        WriteLine("Students:");
        dbJson.GetStudents()?.ForEach(student => AnsiConsole.Markup($"[grey]({student.UserName})[/]\n"));
        MenuResponse(dbJson,dbXml);
    }

    private static void DeleteTeacherMenu(DB dbJson, DB dbXml)
    {
        WriteLine("Teachers:");
        dbJson.GetTeachers()?.ForEach(teacher => AnsiConsole.Markup($"[grey]({teacher.UserName})[/]\n"));
        MenuResponse(dbJson,dbXml);
    }

    private static void DeleteStoreKeeperMenu(DB dbJson, DB dbXml)
    {
        WriteLine("StoreKeepers:");
        dbJson.GetStoreKeepers()?.ForEach(storeKeeper => AnsiConsole.Markup($"[grey]({storeKeeper.UserName})[/]\n"));
        MenuResponse(dbJson,dbXml);
    }

    private static void MenuResponse(DB dbJson, DB dbXml)
    {
        //Type the name of the user to delete
        Write("Enter the name of the user to delete: ");
        string userName = ReadLine() ?? string.Empty;
        //Check if user exist in database
        if (dbJson.HaveUser(userName) || dbXml.HaveUser(userName))
        {
            //Get user
            User user = dbJson.GetUser(userName);
            //Delete user
            dbJson.DeleteUser(user);
            dbXml.DeleteUser(user);
            AnsiConsole.Markup($"[green]User deleted successfully[/]\n");
        }
        else
        {
            AnsiConsole.Markup($"[red]User does not exist[/]\n");
        }
    }

    private static void GenerateReportMenu(StoreKeeper storeKeeper)
    {
        Clear();
        AnsiConsole.Markup($"[green]Welcome to Almacen[/] [grey]({storeKeeper.UserName}: {storeKeeper.TypeOfUser})[/]\n");
        DB dbJson = DBFactory.CreateDB(DBFactory.JSON, gStoreKeeper);
        DB dbXml = DBFactory.CreateDB(DBFactory.XML, gStoreKeeper);
        var menu = AnsiConsole.Prompt(
            new SelectionPrompt<ReportType>()
            .Title("What type of report you want to generate?:")
            .PageSize(6)
            .AddChoices(new[] {
                    ReportType.ReportByClassroom,
                    ReportType.ReportByPayroll,
                    ReportType.ReportBySubject,
                    ReportType.ReportById,
                    ReportType.ReportByUserName,
                    ReportType.Exit,
        }));
        switch (menu)
        {
            case ReportType.ReportByClassroom:

                var report0 = dbJson.GenerateReport(ReportType.ReportByClassroom);
                report0.ForEach(WriteLine);
                AnsiConsole.Markup($"[green]Report generated successfully[/]\n");
                ReadKey();
                break;
            case ReportType.ReportByPayroll:
                var report1 = dbJson.GenerateReport(ReportType.ReportByPayroll);
                report1.ForEach(WriteLine);
                AnsiConsole.Markup($"[green]Report generated successfully[/]\n");
                ReadKey();
                break;
            case ReportType.ReportBySubject:
                var report2 = dbJson.GenerateReport(ReportType.ReportBySubject);
                report2.ForEach(WriteLine);
                AnsiConsole.Markup($"[green]Report generated successfully[/]\n");
                ReadKey();
                break;
            case ReportType.ReportById:
                var report3 = dbJson.GenerateReport(ReportType.ReportById);
                report3.ForEach(WriteLine);
                AnsiConsole.Markup($"[green]Report generated successfully[/]\n");
                ReadKey();
                break;
            case ReportType.ReportByUserName:
                var report4 = dbJson.GenerateReport(ReportType.ReportByUserName);
                report4.ForEach(WriteLine);
                AnsiConsole.Markup($"[green]Report generated successfully[/]\n");
                ReadKey();
                break;
            case ReportType.Exit:
                Environment.Exit(0);
                break;
        }

    }
}