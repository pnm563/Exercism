using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        char[] firstCleanup = phoneNumber.Where(x => Char.IsNumber(x)).ToArray();

        Regex regex = new Regex(@"^1?([2-9]\d{2}[2-9]\d{6}$)");

        Match regexMatch = regex.Match(new string(firstCleanup));

        if (!regexMatch.Success)
            throw new ArgumentException();
        else
            return regexMatch.Groups[1].ToString();
        
    }
}