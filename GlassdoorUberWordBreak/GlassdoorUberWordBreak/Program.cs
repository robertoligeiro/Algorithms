using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassdoorUberWordBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = WordBreak("leetcode", new List<string>() { "leet", "code" });
        }

        public static bool WordBreak(string s, List<string> words)
        {
            var m = new Dictionary<string, int>();
            foreach (var w in words)
            {
                var count = 0;
                if (m.TryGetValue(w, out count)) m[w] = ++count;
                else m.Add(w, 1);
            }
            return WordBreak(s, 0, m);
        }

        public static bool WordBreak(string s, int start, Dictionary<string, int> m)
        {
            if (s.Length == start) return true;
            for (int i = start; i <= s.Length; ++i)
            {
                var key = s.Substring(start, i - start);
                var count = 0;
                if (m.TryGetValue(key, out count) && count > 0)
                {
                    m[key] = --count;
                    if (WordBreak(s, i, m)) return true;
                    m[key] = ++count;
                }
            }
            return false;
        }
    }
}
