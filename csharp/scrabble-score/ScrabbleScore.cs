using System;
using System.Linq;
using System.Collections.Generic;

public static class ScrabbleScore
{
    static readonly (List<char> Letters, int Score)[] Scores =
    {
        ( Letters: "AEIOULNRST".ToList(), Score : 1 )
        ,( Letters: "DG".ToList(), Score : 2 )
        ,( Letters: "BCMP".ToList(), Score : 3 )
        ,( Letters: "FHVWY".ToList(), Score : 4 )
        ,( Letters: "K".ToList(), Score : 5 )
        ,( Letters: "JX".ToList(), Score : 8 )
        ,( Letters: "ZQ".ToList(), Score : 10 )
    };

    public static int Score(string input)
        => input.Select(
            p => Scores.First(
                s => s.Letters.Contains(Char.ToUpper(p))
            )
        ).Select(s => s.Score).Sum();

}
