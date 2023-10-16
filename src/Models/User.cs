using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Almacen.Helpers;
using Almacen.Util;

namespace Almacen.Models
{
    [Serializable]
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
        [System.Text.Json.Serialization.JsonIgnore]
        public string FullName => $"{Name} {LastName} {SurName}";

        public User(string userName, string password)
        {
            Id = Guid.NewGuid().ToString();
            UserName = userName;
            Password = Md5Encryption.GetMd5Hash(password);
            Name = string.Empty;
            LastName = string.Empty;
            SurName = string.Empty;
        }

        public User()
        {
            // Empty constructor
            Id = Guid.NewGuid().ToString();
            UserName = string.Empty;
            Password = string.Empty;
            Name = null;
            LastName = string.Empty;
            SurName = string.Empty;
        }

        public string getPassword()
        {
            return Password;
        }

    }
}