using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercism
{
    class Program
    {
        public static List<int> Factors(int number)
        {
            int i = number;
            List<int> theFactors = new List<int> { 1,number };

            while (i <= number / 2)
            {
                if (i != 0 && number % i == 0) theFactors.Add(i);
                i++;
            }
            return theFactors;
        }

        static void Main(string[] args)
        {
            //List<int> listOne = Factors(Convert.ToInt32(args[0]));
            //List<int> listTwo = Factors(Convert.ToInt32(args[1]));

            //int GCD = listOne.Intersect(listTwo).Max();

            //// breaking before exceptions happen
            //try
            //{
            //    throw new AccessViolationException();
            //    Console.WriteLine("here");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("caught exception");
            //}

            //Console.WriteLine(listOne.Aggregate("", (total, next) =>
            //            total += $"{next},"));                             

            //Console.WriteLine(listTwo.Aggregate("", (total, next) =>
            //            total += $"{next},"));

            Console.WriteLine(-29 * 3);
            Console.WriteLine(29 * -3);
            Console.WriteLine(-29 * -3);

            Console.WriteLine(-81 / 9);
            Console.WriteLine(81 / -9);
            Console.WriteLine(-81 / -9);

            //RationalNumber thing = new RationalNumber(1, 2) / new RationalNumber(-2, 3);

            Console.WriteLine(Math.Pow(81,1.0/2));

        }
    }
}
