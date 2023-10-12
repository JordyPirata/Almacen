using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Almacen.Util;

namespace Almacen.Models;

public abstract class User 
{
    public string Id { get; set; }
    [Required]
    [JsonInclude]
    public string UserName { get; set; }
    [Required]
    [JsonInclude]
    protected string Password { get; set; }
    [JsonInclude]
    public string? Name { get; set; }
    [JsonInclude]
    public string LastName { get; set; }
    [JsonInclude]
    public string SurName { get; set; }
    public string FullName => $"{Name} {LastName} {SurName}";

    public User()
    {
        Id = string.Empty;
        UserName = string.Empty;
        Password = string.Empty;
        Name = string.Empty;
        LastName = string.Empty;
        SurName = string.Empty;
    }
}