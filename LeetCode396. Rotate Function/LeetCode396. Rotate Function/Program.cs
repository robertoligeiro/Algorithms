using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode396.Rotate_Function
{
    class Program
    {
        //https://leetcode.com/problems/rotate-function/discuss/
        //non optimal
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.MaxRotateFunction(new int[] { 4,3,2,6});
        }

        public class Solution
        {
            public int MaxRotateFunction(int[] A)
            {
				var sum = 0;
				foreach (var i in A) sum += i;

				var mult = 0;
				for (int i = 0; i < A.Length; ++i)
				{
					mult += A[i] * i;
				}

				var max = mult;
				for (int i = 1; i < A.Length; ++i)
				{
					var curr = (mult - sum) + (A[i - 1] * A.Length);
					max = Math.Max(max, curr);
					mult = curr;
				}
				return max;
            }
		}
    }
}
