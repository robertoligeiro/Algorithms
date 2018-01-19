using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode274.H_Index
{
    class Program
    {
		//https://leetcode.com/problems/h-index/description/
		static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.HIndex(new int[] { 3,0,6,1,5});
            //var r = s.HIndex(new int[] { 2,1 });
            var r = s.HIndex(new int[] { 3,3,3,0,1,5 });
        }

		public class Solution
		{
			public int HIndex(int[] citations)
			{
				var result = 0;
				citations = citations.OrderBy(x => x).ToArray();
				for (int i = 0; i < citations.Length; ++i)
				{
					var minH = Math.Min(citations[i], citations.Length - i);
					result = Math.Max(result, minH);
				}
				return result;
			}
		}
    }
}
