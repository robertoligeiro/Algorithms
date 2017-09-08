using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode506.RelativeRanks
{
    //https://leetcode.com/problems/relative-ranks/description/
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
                var map = new List<Tuple<int, int>>();
                for (int i = 0; i < nums.Length; ++i)
                {
                    map.Add(new Tuple<int,int>(nums[i], i));
                }
                map.Sort();
                var resp = new string[nums.Length];
                if(map.Count > 0) resp[map.ElementAt(map.Count - 1).Item2] = "Gold Medal";
                if (map.Count > 1) resp[map.ElementAt(map.Count - 2).Item2] = "Silver Medal";
                if (map.Count > 2) resp[map.ElementAt(map.Count - 3).Item2] = "Bronze Medal";
                for (int i = map.Count - 4; i >= 0; --i)
                {
                    resp[map[i].Item2] = (map.Count - i).ToString();
                }
                return resp;
            }
        }
        public class Solution2
        {
            public string[] FindRelativeRanks(int[] nums)
            {
                var heap = new List<int>(nums);
                heap.Sort(Compare);
                var m = new Dictionary<int, int>();
                for (int i = 0; i < heap.Count; ++i)
                {
                    m.Add(heap[i], i + 1);
                }

                var resp = new List<string>();
                foreach (var i in nums)
                {
                    if (m[i] == 1) resp.Add("Gold Medal");
                    else if (m[i] == 2) resp.Add("Silver Medal");
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
