using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Almacen.Helpers;

namespace Almacen.Models
{
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