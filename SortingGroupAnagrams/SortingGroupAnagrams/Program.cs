using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingGroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GroupAnagrams(new List<string>() { "abcd", "abab", "ccbb", "aabb", "cbcb"});
        }

        public static List<string> GroupAnagrams(List<string> a)
        {
            var d = new Dictionary<int, List<string>>();
            foreach (var s in a)
            {
                var sortedS = new string(s.OrderBy(c => c).ToArray());
                var h = sortedS.GetHashCode();
                List<string> l;
                if (d.TryGetValue(h, out l))
                {
                    l.Add(s);
                }
                else d.Add(h, new List<string>() { s });
            }
            var resp = new List<string>();
            foreach (var l in d.Values)
            {
                resp.AddRange(l);
            }
            return resp;
        }
    }
}
