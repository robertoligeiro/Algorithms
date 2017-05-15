using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode506.RelativeRanks
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindRelativeRanks(new int[] { 10, 3, 8, 9, 4 });
        }

        public class Solution
        {
            public string[] FindRelativeRanks(int[] nums)
            {
                var heap = new List<int>(nums);
                heap.Sort(Compare);
                var m = new Dictionary<int, int>();
                for (int i = 0; i < heap.Count; ++i)
                {
                    m.Add(heap[i], i+1);
                }

                var resp = new List<string>();
                foreach (var i in nums)
                {
                    if (m[i] == 1) resp.Add("Gold Medal");
                    else if(m[i] == 2) resp.Add("Silver Medal");
                    else if (m[i] == 3) resp.Add("Bronze Medal");
                    else resp.Add(m[i].ToString());
                }
                return resp.ToArray();
            }

            public int Compare(int a, int b)
            {
                if (b > a) return 1;
                return -1;
            }
        }
    }
}
