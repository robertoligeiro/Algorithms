using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode279.Perfect_Squares
{
    class Program
    {
        //https://leetcode.com/problems/perfect-squares/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.NumSquares(8829);
			var r = s.NumSquares(12);
		}
		public class Solution
        {
            public int NumSquares(int n)
            {
				var q = new Queue<int>();
				q.Enqueue(0);
				var visited = new HashSet<int>();
				var depth = 0;
				while (q.Count > 0)
				{
					var size = q.Count;
					depth++;
					while (size-- > 0)
					{
						var curr = q.Dequeue();
						for (int i = 1; i * i <= n; i++)
						{
							var sum = curr + (i * i);
							if (sum == n) return depth;
							if (sum > n) break;
							if (visited.Add(sum))
							{
								q.Enqueue(sum);
							}
						}
					}
				}
				return depth;
            }
        }
    }
}
