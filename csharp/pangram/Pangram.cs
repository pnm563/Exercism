using System;
using System.Collections.Generic;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        Dictionary<char, int> alphabet = new Dictionary<char, int>();

        CharEnumerator chrs = input.ToUpper().GetEnumerator();

        while (chrs.MoveNext())
        {
            
            if (Char.IsLetter(chrs.Current))
            {
                if (alphabet.ContainsKey(chrs.Current))
                {
                    alphabet[chrs.Current]++;
                }
                else
                {
                    alphabet.Add(chrs.Current, 1);
                }
            }
        }

        return alphabet.Keys.Count() == 26;
    }
}
