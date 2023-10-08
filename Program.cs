// See https://aka.ms/new-console-template for more information
using Almacen.Models;
using static System.Console;

Class class7B = new Class
{
    Id = "7B",
    Name = "18MPEDS0831",
    Teacher = new Teacher
    {
        Id = "13100011",
        Name = "Andres Felipe",
        LastName = "Gaviria Garcia"
    },
    Classroom = new Classroom
    {
        Id = "F-LAB-01"
    },
    Students = new List<string> { "19100011", "19100012", "19100013", "19100014", "19100015" }
};


//Write the entire classroom
WriteLine(class7B);