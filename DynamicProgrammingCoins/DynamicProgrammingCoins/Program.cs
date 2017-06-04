using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = MakeChange(100);
        }

        public static int MakeChange(int n)
        {
            var coins = new int[] { 25, 10, 5, 1 };
            return MakeChange(n, coins, 0);
        }

        public static int MakeChange(int amount, int[] coins, int index)
        {
            if (index == coins.Length) return 1;
            var cointAmount = coins[index];
            var ways = 0;
            for (int i = 0; i * cointAmount <= amount; ++i)
            {
                var remaining = amount - (i * cointAmount);
                ways += MakeChange(remaining, coins, index + 1);
            }
            return ways;
        }
    }
}
