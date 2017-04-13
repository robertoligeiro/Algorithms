using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesFindLongestContainedInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindLongestInterval(new List<int>() { 3, -2, 7, 9, 8, 1, 2, 0, -1, 5, 8 });
        }

        public static int FindLongestInterval(List<int> a)
        {
            var map = new HashSet<int>(a);
            var maxSoFar = 0;
            while (map.Count > 0)
            {
                var seed = map.FirstOrDefault();
                var i = seed;
                var localCount = 0;
                while (map.Contains(i))
                {
                    localCount++;
                    map.Remove(i++);
                }
                i = seed - 1;
                while (map.Contains(i))
                {
                    localCount++;
                    map.Remove(i--);
                }

                maxSoFar = Math.Max(localCount, maxSoFar);
            }

            return maxSoFar;
        }
    }
}
