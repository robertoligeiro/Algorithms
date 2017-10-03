using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode49.Group_Anagrams
{
    class Program
    {
        //https://leetcode.com/problems/group-anagrams/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        }
        public class Solution
        {
            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                var map = new Dictionary<string, List<string>>();
                foreach (var s in strs)
                {
                    var sorted = new string(s.OrderBy(c => c).ToArray());
                    List<string> l;
                    if (!map.TryGetValue(sorted, out l))
                    {
                        map.Add(sorted, new List<string>() { s });
                    }
                    else l.Add(s);
                }
                var resp = new List<IList<string>>();
                foreach (var l in map.Values)
                {
                    resp.Add(l);
                }
                return resp;
            }
        }
    }
}
