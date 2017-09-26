using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode137.Single_Number_II
{
    class Program
    {
        //https://leetcode.com/problems/single-number-ii/description/
        static void Main(string[] args)
        {
        }

        public class Solution
        {
            public int SingleNumber(int[] nums)
            {
                var isNot = new HashSet<int>();
                var canBe = new HashSet<int>();
                foreach (var i in nums)
                {
                    if (!isNot.Add(i)) canBe.Remove(i);
                    else canBe.Add(i);
                }
                return canBe.First();
            }
        }
    }
}
