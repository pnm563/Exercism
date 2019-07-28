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
            var input = new Dictionary<int, string[]>
            {
                [1] = new[] { "A", "E", "I", "O", "U" },
                [2] = new[] { "D", "G" }
            };

            Dictionary<int, string> returnedDict = new Dictionary<int, string>();

            //var thing = input.SelectMany(p => p.Value, resultSelector: (p, c) => new { p.Key, c });
            var thing = input.SelectMany(scoreInfo => scoreInfo.Value, (score, Letter) => new { score.Key, Letter });

            thing.ToDictionary(v => v.Key, w => w.Letter.ToLower());
        }
    }
}
