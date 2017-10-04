using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode477.Total_Hamming_Distance
{
    class Program
    {
        //https://leetcode.com/problems/total-hamming-distance/description/
        //solution: https://leetcode.com/problems/total-hamming-distance/discuss/
        static void Main(string[] args)
        {
        }

        public class Solution
        {
            public int TotalHammingDistance(int[] nums)
            {
                var numsCount = nums.Length;
                var hDist = 0;
                for (int i = 0; i < 32; ++i)
                {
                    var totBits = 0;
                    foreach (var num in nums)
                    {
                        totBits += (num >> i) & 1;
                    }
                    hDist += totBits * (numsCount - totBits);
                }
                return hDist;
            }
        }
    }
}
