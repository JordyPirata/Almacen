using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Almacen.Models
{
    [Serializable]
    public abstract class User
    {
        [Required]
        [JsonInclude]
        public string Id { get; set; }
        [Required]
        [JsonInclude]
        private string UserName;
        [Required]
        [JsonInclude]
        private string Password;
        [Required]
        [JsonInclude]
        public string? Name { get; set; }
        [Required]
        [JsonInclude]
        public string LastName { get; set; }
        [Required]
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

        public string GetUserName()
        {
            return UserName;
        }
        public string getPassword()
        {
            return Password;
        }
    }
}