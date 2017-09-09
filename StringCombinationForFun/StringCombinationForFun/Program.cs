using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCombinationForFun
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetComb("aabcd");
            var r1 = GetPermut("aabcd");
        }

        //permut
        public static List<string> GetPermut(string s)
        {
            var m = new Dictionary<char, int>();
            foreach (var c in s)
            {
                var count = 0;
                if (m.TryGetValue(c, out count))
                {
                    m[c] = ++count;
                }
                else m.Add(c, 1);
            }

            var resp = new List<string>();
            var parc = new List<char>();
            GetPermut(s, m, resp, parc);
            return resp;
        }
        public static void GetPermut(string s, Dictionary<char, int> m, List<string> resp, List<char> parc)
        {
            if (parc.Count == s.Length)
            {
                resp.Add(new string(parc.ToArray()));
                return;
            }
            for (int i = 0; i < m.Count; ++i)
            {
                var t = m.ElementAt(i);
                if (t.Value > 0)
                {
                    m[t.Key]--;
                    parc.Add(t.Key);
                    GetPermut(s, m, resp, parc);
                    m[t.Key]++;
                    parc.RemoveAt(parc.Count - 1);
                }
            }
        }
        //comb
        public static List<string> GetComb(string s)
        {
            var m = new Dictionary<char, int>();
            foreach (var c in s)
            {
                var count = 0;
                if (m.TryGetValue(c, out count))
                {
                    m[c] = ++count;
                }
                else m.Add(c, 1);
            }

            var resp = new List<string>();
            GetComb(s, m, resp, string.Empty, 0);
            return resp;
        }

        public static void GetComb(string s, Dictionary<char, int> m, List<string> resp, string parc, int start)
        {
            resp.Add(parc);
            if (parc.Length == s.Length) return;
            for (int i = start; i < m.Count; ++i)
            {
                var t = m.ElementAt(i);
                if (t.Value > 0)
                {
                    m[t.Key]--;
                    GetComb(s, m, resp, parc + t.Key, i);
                    m[t.Key]++;
                }
            }
        }
    }
}
