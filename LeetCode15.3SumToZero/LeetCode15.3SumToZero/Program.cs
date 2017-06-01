using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode15._3SumToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            //var r = s.ThreeSum(new int[] { 0, 0, 0, 0 });
        }

        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                var l = new List<int>(nums);
                l.Sort();
                var resp = new List<IList<int>>();
                var set = new HashSet<string>();
                for (int i = 0; i < l.Count; ++i)
                {
                    var s = i + 1;
                    var e = l.Count - 1;
                    while (s < e)
                    {
                        var sum = l[i] + l[s] + l[e];
                        if (sum == 0 && set.Add(l[i].ToString()+ l[s].ToString()+l[e].ToString()))
                        {
                            resp.Add(new List<int>() { l[i], l[s], l[e] });
                            e--;
                        }
                        else if (sum < 0) s++;
                        else e--;
                    }
                }

                return resp;
            }
        }

    }
}
