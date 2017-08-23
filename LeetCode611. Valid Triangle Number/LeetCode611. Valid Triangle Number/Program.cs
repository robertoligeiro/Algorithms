using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode611.Valid_Triangle_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.TriangleNumber(new int[] { 2,2,3,4});
        }
        public class Solution
        {
            public int TriangleNumber(int[] nums)
            {
                var lnums = new List<int>(nums);
                lnums.Sort();
                var resp = 0;
                for (int i = 0; i < lnums.Count; ++i)
                {
                    for (int j = i + 1; j < lnums.Count && lnums[i] != 0; ++j)
                    {
                        var cSideLimit = lnums[i] + lnums[j];
                        var k = j + 1;
                        while (k < lnums.Count && cSideLimit > lnums[k])
                        {
                            k++;
                        }
                        resp += k - j - 1;
                    }
                }
                return resp;
            }
        }
    }
}
