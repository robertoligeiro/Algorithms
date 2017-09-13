using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode47.Permutations_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.PermuteUnique(new int[] { 1, 1, 2 });
        }
        public class Solution
        {
            public IList<IList<int>> PermuteUnique(int[] nums)
            {
                var m = new Dictionary<int, int>();
                foreach (var i in nums)
                {
                    var count = 0;
                    if (m.TryGetValue(i, out count))
                    {
                        m[i] = ++count;
                    }
                    else m.Add(i, 1);
                }

                var resp = new List<IList<int>>();
                var parc = new List<int>();
                GetPermut(nums, m, resp, parc);
                return resp;
            }

            private void GetPermut(int[] nums, Dictionary<int, int> m, List<IList<int>> resp, List<int> parc)
            {
                if (parc.Count == nums.Length)
                {
                    resp.Add(new List<int>(parc));
                    return;
                }

                for (int i = 0; i < m.Count; ++i)
                {
                    var t = m.ElementAt(i);
                    if (t.Value > 0)
                    {
                        m[t.Key]--;
                        parc.Add(t.Key);
                        GetPermut(nums, m, resp, parc);
                        m[t.Key]++;
                        parc.RemoveAt(parc.Count - 1);
                    }
                }
            }
        }
    }
}
