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
        [Required]
        [JsonInclude]
        public string TypeOfUser { get; set; }
        public User(string userName, string password)
        {
            Id = Guid.NewGuid().ToString();
            UserName = userName;
            Password = Md5Encryption.GetMd5Hash(password);
            TypeOfUser = string.Empty;
        }
        public User()
        {
            // Empty constructor
            Id = Guid.NewGuid().ToString();
            UserName = string.Empty;
            Password = string.Empty;
            TypeOfUser = string.Empty;
        }
    }
}