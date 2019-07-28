using System;
public static class Grains
{

    public static ulong Square(int n)
    {
        if (n > 0 && n < 65)
        {
            return (ulong)1 << n - 1;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public static ulong Total()
    {
        ulong total = 0;

        for (int i = 1; i < 65; i++)
        {
            total += Square(i);
        }

        return total;


    }
}


