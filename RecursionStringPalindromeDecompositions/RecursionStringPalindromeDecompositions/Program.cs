using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionStringPalindromeDecompositions
{
    class Program
    {
        static void Main(string[] args)
        {
            var r1 = GetPalindromeDeco("0204451881");
        }

        public static List<List<string>> GetPalindromeDeco(string s)
        {
            var resp = new List<List<string>>();
            var parc = new List<string>();
            GetPalindromeDeco(s, resp, parc, 0);
            return resp;
        }
        public static void GetPalindromeDeco(string s, List<List<string>> resp, List<string> parc, int index)
        {
            if (index == s.Length)
            {
                resp.Add(new List<string>(parc));
                return;
            }
            for (int i = index; i < s.Length; ++i)
            {
                if (IsPal(s, index, i))
                {
                    parc.Add(s.Substring(index, i - index + 1));
                    GetPalindromeDeco(s, resp, parc, i + 1);
                    parc.RemoveAt(parc.Count - 1);
                }
            }
        }

        public static bool IsPal(string s, int l, int r)
        {
            while (l < r)
            {
                if (s[l++] != s[r--]) return false;
            }
            return true;
        }
    }
}
