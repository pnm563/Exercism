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
            //Enumerable.Range(1, 100).ToList().ForEach(n => Console.WriteLine(n));
            IEnumerable<int> listy = Enumerable.Range(4, 2);

            string thing = TwelveDays.Recite(12);

        }
    }
}
