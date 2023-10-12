using System.Text.Json.Serialization;

namespace Almacen.Models;

[Serializable]
public class Teacher : User
{
    [JsonInclude]
    protected decimal Salary { get; set; }

}