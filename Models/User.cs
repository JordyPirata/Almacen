using System.ComponentModel.DataAnnotations;

namespace Almacen.Models
{
    [Serializable]
    public abstract class User
    {
        [Required]
        private string UserName;
        [Required]
        private string Password;


        public void SetUser(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public User()
        {
            UserName = string.Empty;
            Password = string.Empty;
        }

        public void SetUserName(string userName)
        {
            UserName = userName;
        }

        public void SetPassword(string password)
        {
            Password = password;
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