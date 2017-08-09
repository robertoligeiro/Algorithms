using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode438.FindAllAnagramsinaString
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindAnagrams("baa", "aa");
        }
        public class Solution
        {
            public IList<int> FindAnagrams(string s, string p)
            {
                var m = new int[256];
                foreach (var c in p)
                {
                    m[c]++;
                }
                var resp = new List<int>();
                var r = 0;
                var l = 0;
                var count = p.Length;
                while(r < s.Length)
                {
                    if (m[s[r++]]-- >= 1) count--;

                    if (count == 0) resp.Add(l);

                    if (r - l == p.Length && m[s[l++]]++ >= 0) count++;
                }
                return resp;
            }
        }
    }
}
