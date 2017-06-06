using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonPhoneInterviewGetPairsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetPairs(new List<int>() { 2, 4, 1, -9, 5, 3, 5, 2, 8, 8  }, 10);
        }

        public static List<Tuple<int, int>> GetPairs(List<int> values, int target)
        {
            var counters = new Dictionary<int, int>();
            var response = new List<Tuple<int, int>>();

            foreach (var i in values)
            {
                var count = 0;
                var diff = target - i;

                // Check if the entry is already in the waiting list 
                // as a compliment, if so, generate combinations
                if (counters.TryGetValue(i, out count))
                {
                    while (count-- > 0)
                    {
                        response.Add(new Tuple<int, int>(diff, i));
                    }
                }

                // add compliments to list of waiting
                count = 0;
                if (counters.TryGetValue(diff, out count))
                {
                    counters[diff] = ++count;
                }
                else
                {
                    counters.Add(diff, 1);
                }
            }

            return response;
        }
    }
}
