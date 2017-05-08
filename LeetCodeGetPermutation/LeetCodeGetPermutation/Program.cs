using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGetPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.GetPermutation(9, 100);
        }
        public class Solution
        {
            public string GetPermutation(int n, int k)
            {
                var values = Enumerable.Range(1, n).ToList();
                var counters = Enumerable.Repeat(1, n).ToList();
                var resp = new List<List<int>>();
                var parc = new List<int>();
                GetPermutations(values, counters, parc, resp, k);
                return string.Join("", resp.Last());
            }

            public void GetPermutations(List<int> values, List<int> counters, List<int> parc, List<List<int>> resp, int k)
            {
                if (parc.Count == values.Count)
                {
                    resp.Add(new List<int>(parc));
                    return;
                }

                var lCounters = new List<int>(counters);
                var lParc = new List<int>(parc);
                for (int i = 0; i < lCounters.Count; ++i)
                {
                    if (lCounters[i] == 1)
                    {
                        lCounters[i] = 0;
                        lParc.Add(values[i]);
                        GetPermutations(values, lCounters, lParc, resp, k);
                        lCounters[i] = 1;
                        lParc.RemoveAt(lParc.Count - 1);
                        if (resp.Count == k) return;
                    }
                }
            }
        }
    }
}
