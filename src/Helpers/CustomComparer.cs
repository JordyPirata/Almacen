using System.Text.RegularExpressions;

namespace Almacen.Helpers;

public class CustomComparer : IComparer<string>
{
    public int Compare(string? x , string? y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException();
        }
        //Extracts alphanumeric and numeric characters from a string
        string patern = @"([a-zA-Z]+)(\d+)";

        var xMatch = Regex.Match(x, patern);
        var yMatch = Regex.Match(y, patern);

        //Compare alphabetical part
        int compareAlphabetical = string.Compare(xMatch.Groups[1].Value, yMatch.Groups[1].Value);

        //If alphabetical part is equal, compare numerical part
        if(compareAlphabetical == 0)
        {
            //Convert numerical part to int
            int xNumber = int.Parse(xMatch.Groups[2].Value);
            int yNumber = int.Parse(yMatch.Groups[2].Value);

            //Compare numerical part
            return xNumber.CompareTo(yNumber);
        }
        return compareAlphabetical;
    }
    public int CompareTo(string other)
    {
        // Implementación del método CompareTo para IComparable<string>
        return Compare(this.ToString(), other);
    }
    
    


}


