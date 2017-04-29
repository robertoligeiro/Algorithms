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
            var r = GetPalDeco("0204451881");
        }

        public static List<List<string>> GetPalDeco(string s)
        {
            var resp = new List<List<string>>();
            var parc = new List<string>();
            GetPalDeco(s, resp, parc);
            return resp;
        }

        public static void GetPalDeco(string s, List<List<string>> r, List<string> p)
        {
            if (s.Length == 0)
            {
                r.Add(new List<string>(p));
                return;
            }

            for (int i = 0; i < s.Length; ++i)
            {
                var t = s.Substring(0, i + 1);
                if (IsPalindrome(t))
                {
                    var localP = new List<string>(p);
                    localP.Add(t);
                    GetPalDeco(s.Substring(i + 1, s.Length - i - 1), r, localP);
                }
            }
        }

        public static bool IsPalindrome(string s)
        {
            for (int i = 0, j = s.Length - 1; i < j; ++i, --j)
            {
                if (s[i] != s[j]) return false;
            }
            return true;
        }
    }
}
