using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercism
{
    class Program
    {
        static void Main(string[] args)
        {
            Enumerable.Range(1, 100).ToList().ForEach(n => Console.WriteLine(n));

        }

        public static bool IsArmstrongNumber(int number)
        {
            var xs = Digits(number).ToList();

            return number == xs.Sum(x => Math.Pow(x, xs.Count()));
        }

        private static IEnumerable<int> Digits(int number)
        {
            while (number > 0)
            {
                yield return number % 10;
                number /= 10;
            }
        }
    }
}
