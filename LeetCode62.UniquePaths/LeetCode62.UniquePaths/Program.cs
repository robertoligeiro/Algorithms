using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode62.UniquePaths
{
    class Program
    {
        // DP Solution is from here: https://discuss.leetcode.com/topic/15265/0ms-5-lines-dp-solution-in-c-with-explanations/2
        // BSF solution is mine, time exceeds in leetcode.
        //problem: https://leetcode.com/problems/unique-paths/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.UniquePaths(23, 12);
        }

        class Solution
        {
            public int UniquePaths(int m, int n)
            {
                if (m > n) return UniquePaths(n, m);
                var cur = Enumerable.Repeat(1, m).ToArray();
                for (int j = 1; j < n; j++)
                    for (int i = 1; i < m; i++)
                        cur[i] += cur[i - 1];
                return cur[m - 1];
            }
        }

        public class SolutionBSF
        {
            public int UniquePaths(int m, int n)
            {
                var start = new Tuple<int, int>(0, 0);
                var q = new Queue<Tuple<int, int>>();
                q.Enqueue(start);
                var visited = new Dictionary<Tuple<int, int>, int>();
                var resp = 0;
                while (q.Count > 0)
                {
                    var curr = q.Dequeue();
                    GetNext(curr, q, m, n);
                    if (curr.Item1 == m - 1 && curr.Item2 == n - 1)
                    {
                        resp++;
                    }
                }
                return resp;
            }

            private void GetNext(Tuple<int, int> curr, Queue<Tuple<int, int>> q, int m, int n)
            {
                var right = curr.Item2 + 1;
                var down = curr.Item1 + 1;
                if (right < n) q.Enqueue(new Tuple<int, int>(curr.Item1, right));
                if (down < m) q.Enqueue(new Tuple<int, int>(down, curr.Item2));
            }
        }
    }
}
