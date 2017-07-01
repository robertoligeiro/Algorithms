using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode40.CombinationSumII
{
    class Program
    {
        //https://leetcode.com/problems/combination-sum-ii/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.CombinationSum2(new int[] { 10,1,2,7,6,1,5}, 8);
        }
        public class Solution
        {
            public IList<IList<int>> CombinationSum2(int[] candidates, int target)
            {
                var resp = new List<IList<int>>();
                var parc = new List<int>();
                var can = new List<int>(candidates);
                var h = new HashSet<string>();
                can.Sort();
                Comb(can, resp, parc, 0, target, 0, h);
                return resp;
            }

            private void Comb(List<int> candidates, List<IList<int>> r, List<int> p, int index, int tgt, int acc, HashSet<string> h)
            {
                if (acc == tgt)
                {
                    if (h.Add(string.Join("", p)))
                    {
                        r.Add(new List<int>(p));
                    }
                    return;
                }
                if (acc > tgt) return;

                for (int i = index; i < candidates.Count; ++i)
                {
                    acc += candidates[i];
                    p.Add(candidates[i]);
                    Comb(candidates, r, p, i+1, tgt, acc, h);
                    acc -= p[p.Count - 1];
                    p.RemoveAt(p.Count - 1);
                }
            }
        }
    }
}
