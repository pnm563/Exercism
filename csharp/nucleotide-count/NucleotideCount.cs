using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    private static IEnumerable<char> _allowedNucleotides = "ACGT";

    public static IDictionary<char, int> Count(string sequence)
    {
        if (!sequence.Distinct().All(_allowedNucleotides.Contains))
            throw new ArgumentException();

        Dictionary<char,int> dictReturn = new Dictionary<char, int>()
        {
            ['A'] = 0
            ,['C'] = 0
            ,['G'] = 0
            ,['T'] = 0

        };

        sequence.ToList().ForEach(n => dictReturn[n]++); 

        return dictReturn;
    }
}