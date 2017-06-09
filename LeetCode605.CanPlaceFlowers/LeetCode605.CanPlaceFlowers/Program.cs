using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode605.CanPlaceFlowers
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var b = s.CanPlaceFlowers(new int[] { 0, 0, 1, 0, 0, 0, 1, 0, 0 }, 3); // exp: true;
            b = s.CanPlaceFlowers(new int[] { 0, 0, 1, 0, 0, 0, 1, 0, 0 }, 4); // exp: false;
        }

        public class Solution
        {
            public bool CanPlaceFlowers(int[] flowerbed, int n)
            {
                var acc = 1;
                var count = 0;
                foreach (var i in flowerbed)
                {
                    if (i == 0)
                    {
                        if (acc == -1) acc = 1;
                        else
                        {
                            if (++acc == 3)
                            {
                                count++;
                                acc = 1;
                            }
                        }
                    }
                    else acc = -1;
                }

                if (acc == 2) ++count;
                return count >= n;
            }
        }
    }
}
