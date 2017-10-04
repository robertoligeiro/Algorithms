using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode77.Combinations
{
    class Program
    {
        //https://leetcode.com/problems/combinations/description/
        // Tushar method!
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.Combine(3, 3);
        }
        public class Solution
        {
            public IList<IList<int>> Combine(int n, int k)
            {
                var resp = new List<IList<int>>();
                var parc = new List<int>();
                var source = Enumerable.Range(1, n).ToList();
                Combine(source, resp, parc, k, 0);
                return resp;
            }
            private void Combine(List<int> source, List<IList<int>> resp, List<int>parc, int k, int index)
            {
                if (parc.Count == k)
                {
                    resp.Add(new List<int>(parc));
                    return;
                }
                if (index >= source.Count)
                {
                    return;
                }
                for (int i = index; i < source.Count; ++i)
                {
                    parc.Add(source[i]);
                    Combine(source, resp, parc, k, i + 1);
                    parc.RemoveAt(parc.Count - 1);
                }
            }
        }
    }
}
