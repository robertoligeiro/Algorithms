using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionGetStringPermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetStringPermut("aabc");
        }

        public static List<string> GetStringPermut(string s)
        {
            var dict = GetCharCount(s);
            var resp = new List<string>();
            var parc = new StringBuilder();
            GetStringPermut(s, dict, parc, resp);
            return resp;
        }

        public static void GetStringPermut(string s, Dictionary<char, int> m, StringBuilder p, List<string> resp)
        {
            if (s.Length == p.Length)
            {
                resp.Add(new string(p.ToString().ToArray()));
            }

            foreach(var t in m)
            {
                if (t.Value > 0)
                {
                    var ldict = new Dictionary<char, int>(m);
                    ldict[t.Key] = t.Value - 1;
                    p.Append(t.Key);
                    GetStringPermut(s, ldict, p, resp);
                    p.Remove(p.Length - 1, 1);
                }
            }
        }

        public static Dictionary<char, int> GetCharCount(string s)
        {
            var dict = new Dictionary<char, int>();
            foreach (var c in s)
            {
                var count = 0;
                if (dict.TryGetValue(c, out count))
                {
                    dict[c] = count + 1;
                }
                else
                    dict.Add(c, 1);
            }
            return dict;
        }
    }
}
