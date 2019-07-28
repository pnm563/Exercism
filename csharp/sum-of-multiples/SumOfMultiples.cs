using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        List<HashSet<int>> rawData = new List<HashSet<int>>();

        foreach (int multiple in multiples)
        {
            int i;
            HashSet<int> multSet = new HashSet<int>();

            for (i = 1; (long)i * multiple < max; i++)
            {
                multSet.Add(i * multiple);
            }
            rawData.Add(multSet);
        }
        return rawData.SelectMany(p => p).Distinct().Sum();
    }
}