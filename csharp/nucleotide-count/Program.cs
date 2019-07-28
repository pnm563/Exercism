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
            string input = args[0];
            IEnumerable<char> allowed = "ACGT";

                if(input.Distinct().All(allowed.Contains))
            {
                Console.WriteLine("Things");
            }
            Console.WriteLine("nothingS");
            //Console.ReadKey();
            
        }
    }
}
