using System;
using System.Collections.Generic;
using System.Linq;

public static class Raindrops
{
    public static void Main(string[] args)
    {
        string thing = "stop me";
    }

    public static string Convert(int number)
    {
        Dictionary<int, string> dropDict = new Dictionary<int, string> {
            { 3 ,"Pling" }
            ,{ 5 ,"Plang" }
            ,{ 7 , "Plong" }
        };

        IEnumerable<string> drops = dropDict.Keys
            .Where(df => number % df == 0)  // filter list down to factors of number
            .Select(p => dropDict[p])       // .Select creates projected values according to dropDict key
            .DefaultIfEmpty(number.ToString());

        return drops.Aggregate((a, b) => $"{a}{b}"); // vs. String.Join("",drops);
        
    }

    
}
