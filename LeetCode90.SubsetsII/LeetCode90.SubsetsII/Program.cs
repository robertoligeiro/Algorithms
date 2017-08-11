using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode90.SubsetsII
{
    class Program
    {
        //https://leetcode.com/problems/subsets-ii/description/
        static void Main(string[] args)
        {
        }

        public class Solution
        {
            public IList<IList<int>> SubsetsWithDup(int[] nums)
            {
                var resp = new List<IList<int>>();
                var parc = new List<int>();
                var m = GetMap(nums);
                SubsetsWithDup(m, resp, parc, 0);
                return resp; 
            }

            private void SubsetsWithDup(Dictionary<int, int> m, List<IList<int>> resp, List<int> parc, int start)
            {
                if (start >= m.Count) return;
                resp.Add(new List<int>(parc));
                for (int i = start; i < m.Count; ++i)
                {
                    if (m.ElementAt(i).Value > 0)
                    {
                        m[m.ElementAt(i).Key]--;
                        parc.Add(m.ElementAt(i).Key);
                        SubsetsWithDup(m, resp, parc, i);
                        m[m.ElementAt(i).Key]++;
                        parc.RemoveAt(parc.Count-1);
                    }
                }
            }
            private Dictionary<int, int> GetMap(int[] nums)
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
                return m;
            }
        }
    }
}
