using System;
using System.Collections.Generic;
using System.Linq;

public static class TwelveDays
{
    private static Dictionary<int, string> DaysAndThings = new Dictionary<int, string>() {
        [1] = "a Partridge in a Pear Tree."
        ,[2] = "two Turtle Doves" 
        ,[3] = "three French Hens"
        ,[4] = "four Calling Birds"
        ,[5] = "five Gold Rings"
        ,[6] = "six Geese-a-Laying"
        ,[7] = "seven Swans-a-Swimming"
        ,[8] = "eight Maids-a-Milking"
        ,[9] = "nine Ladies Dancing"
        ,[10] = "ten Lords-a-Leaping"
        ,[11] = "eleven Pipers Piping"
        ,[12] = "twelve Drummers Drumming"
    };

    private static Dictionary<int, string> NumberAdjective = new Dictionary<int, string>()
    {
        [1] = "first"
        ,[2] = "second"
        ,[3] = "third"
        ,[4] = "fourth"
        ,[5] = "fifth"
        ,[6] = "sixth"
        ,[7] = "seventh"
        ,[8] = "eighth"
        ,[9] = "ninth"
        ,[10] = "tenth"
        ,[11] = "eleventh"
        ,[12] = "twelfth"
    };

    public static string Recite(int verseNumber)
    {
        // Obtain all the accumulated gifts for this nth day of Christmas
        string inventory = Inventory(verseNumber);

        // Create the preamble
        string preamble = $"On the {NumberAdjective[verseNumber]} day of Christmas my true love gave to me: ";
        
        // Bring them together to create the verse
        return $"{preamble}{inventory}";
    }

    public static string Inventory(int verseNumber)
    {
        // Make sure that the 'and' is put in the right place, all other conjutions will be a comma
        string conjunction = verseNumber == 2 ? ", and " : ", ";

        // This terminates the recursive algorithm
        if (verseNumber == 1) return DaysAndThings[1];
        else
            // Use recursion to accumulate the gifts. It's always today plus whatever you had yesterday
            return $"{DaysAndThings[verseNumber]}{conjunction}{Inventory(verseNumber - 1)}";
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return Enumerable.Range(startVerse, endVerse - startVerse + 1)  // Arguments are (Start Number, Set Size), e.g. (4,3) = (4,5,6)
            .Select(x => Recite(x))                                     // Transform each int into the corresponding verse string
            .Aggregate((x, y) => $"{x}\n{y}");                          // Concatenate the strings in the collection with a \n in between each one
    }
}