using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode462.MiniMovestoEqualArrayElementsII
{
    class Program
    {
        //https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/description/
        static void Main(string[] args)
        {
        }
        public class Solution
        {
            public int MinMoves2(int[] nums)
            {
                var l = new List<int>(nums);
                l.Sort();
                var i = 0;
                var j = l.Count - 1;
                var count = 0;
                while (i < j)
                {
                    count += (l[j--] - l[i++]);
                }
                return count;
            }
        }
    }
}
