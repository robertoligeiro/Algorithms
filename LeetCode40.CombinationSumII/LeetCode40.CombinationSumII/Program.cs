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

			var ss = new SolutionNew();
			var rr = ss.CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
		}

		public class SolutionNew
		{
			public IList<IList<int>> CombinationSum2(int[] candidates, int target)
			{
				candidates = candidates.OrderBy(x => x).ToArray();
				var parc = new List<int>();
				var resp = new List<IList<int>>();
				CombinationSum2(candidates, parc, resp, new HashSet<string>(), string.Empty, 0, target);
				return resp;
			}
			private void CombinationSum2(int[] candidates, List<int> parc, List<IList<int>> resp, HashSet<string> added, string parcS, int i, int target)
			{
				if (i >= candidates.Length || target < 0) return;
				if (target == 0)
				{
					if (added.Add(parcS))
					{
						resp.Add(new List<int>(parc));
					}
					return;
				}
				parc.Add(candidates[i]);
				CombinationSum2(candidates, parc, resp, added, string.Join("", parc), i + 1, target - candidates[i]);
				parc.RemoveAt(parc.Count - 1);
				CombinationSum2(candidates, parc, resp, added, string.Join("", parc), i + 1, target);
			}
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
