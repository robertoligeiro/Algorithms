using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionDynamicProgrammingCoinsChange
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = MinCoinsChange(32);
        }

        public static int MinCoinsChange(int val)
        {
            var coins = new int[] { 25, 10, 5, 1 };
            var cache = Enumerable.Repeat(-1, val).ToArray();
            return MinCoinsChange(val, coins, cache);
        }
        public static int MinCoinsChange(int val, int[] coins, int[] cache)
        {
            if (val == 0) return 0;

            var min = val;
            foreach (var coin in coins)
            {
                var remaning = val - coin;
                if (remaning >= 0)
                {
                    int localMin = 0;
                    if (cache[remaning] == -1)
                    {
                        localMin = MinCoinsChange(remaning, coins, cache);
                        cache[remaning] = localMin;
                    } else localMin = cache[remaning];
                    if (min > localMin + 1) min = localMin + 1;
                }
            }

            return min;
        }
    }
}
