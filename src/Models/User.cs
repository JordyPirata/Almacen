using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Almacen.Models;

public abstract class User
{
    public string Id { get; set; }
    [Required]
    [JsonInclude]
    public string UserName { get; set; }
    [Required]
    [JsonInclude]
    public string Password { get; set; }
    [JsonInclude]
    public string? Name { get; set; }
    [JsonInclude]
    public string LastName { get; set; }
    [JsonInclude]
    public string SurName { get; set; }
    public string FullName => $"{Name} {LastName} {SurName}";
    public void SetUser(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
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