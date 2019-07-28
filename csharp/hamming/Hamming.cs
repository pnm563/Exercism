using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length == secondStrand.Length)
        {
            int hammingDistance = 0;
            CharEnumerator firstStrandSet = firstStrand.GetEnumerator();
            CharEnumerator secondStrandSet = secondStrand.GetEnumerator();

            while (firstStrandSet.MoveNext())
            {
                secondStrandSet.MoveNext();
                if (firstStrandSet.Current != secondStrandSet.Current) hammingDistance++;

            }

            return hammingDistance;
        }
        else
        {
            throw new ArgumentException();
        }
    }
}