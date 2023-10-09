using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Helpers
{
    public class Md5Password
    {
        //encrypt and decrypt password
        public static string EncryptPassword(string password)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var result = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));
                var strResult = System.Text.Encoding.ASCII.GetString(result);
                return strResult;
            }
        }
    }
    
    
}