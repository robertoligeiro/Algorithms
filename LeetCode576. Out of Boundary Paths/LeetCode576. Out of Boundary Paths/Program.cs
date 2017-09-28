using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode576.Out_of_Boundary_Paths
{
    //https://leetcode.com/problems/out-of-boundary-paths/description/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.FindPaths(2,2,2,0,0);
            var r = s.FindPaths(1, 3, 3, 0, 1);
        }

        public class Solution
        {
            public int FindPaths(int m, int n, int N, int i, int j)
            {
                return FindPaths(m, n, N, i, j, new Dictionary<Tuple<int, int>, int>());
            }

            private int FindPaths(int m, int n, int N, int i, int j, Dictionary<Tuple<int, int>, int> memo)
            {
                if (i == m || j == n || i < 0 || j < 0) return 1;
                if (N == 0) return 0;
                var curr = new Tuple<int, int>(i,j);
                var count = 0;
                if (!memo.TryGetValue(curr, out count))
                {
                    count = FindPaths(m, n, N-1, i + 1, j, memo) + 
                            FindPaths(m, n, N-1, i - 1, j, memo) + 
                            FindPaths(m, n, N-1, i, j + 1, memo) + 
                            FindPaths(m, n, N - 1, i, j - 1, memo);
                }
                return count;
            }
        }
    }
}
