using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Helpers;
public class Md5Encryption
{

    // Hash an input string and return the hash as
    public static string GetMd5Hash(string input)
    {
        using var md5Hash = System.Security.Cryptography.MD5.Create();
        var data = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
        var sBuilder = new System.Text.StringBuilder();
        foreach (var t in data)
        {
            sBuilder.Append(t.ToString("x2"));
        }
        return sBuilder.ToString();
    }
    // Verify a hash against a string.
    public static bool VerifyMd5Hash(string input, string hash)
    {
        var hashOfInput = GetMd5Hash(input);
        var comparer = StringComparer.OrdinalIgnoreCase;
        return 0 == comparer.Compare(hashOfInput, hash);
    }
}