using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var newSystem = old.SelectMany(score => score.Value, resultSelector: (score, Letter) => new { score.Key, Letter });

        return newSystem.ToDictionary(v => v.Letter.ToLower(), w => w.Key);

    }
}