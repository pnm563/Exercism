using System;

public static class CollatzConjecture
{
    private static int NoOfSteps { get; set; } = 0;

    public static int Steps(int number)
    {
        if (number <= 0) throw new ArgumentException();

        if (number == 1)
        {
            int returnedNoOfSteps = NoOfSteps;
            NoOfSteps = 0;
            return returnedNoOfSteps;
        }

        NoOfSteps++;

        return (number % 2 == 0) ? Steps(number / 2) : Steps(number * 3 + 1);

    }
}