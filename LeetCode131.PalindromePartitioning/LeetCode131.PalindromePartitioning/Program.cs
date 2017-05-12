using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode131.PalindromePartitioning
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.Partition("abaa");
        }

        public class Solution
        {
            public IList<IList<string>> Partition(string s)
            {
                var resp = new List<IList<string>>();
                var parc = new StringBuilder();
                for (int i = 0; i < s.Length; ++i)
                {
                    parc.Append(s[i]);
                    var s1 = parc.ToString();
                    if (IsPal(s1))
                    {
                        if (i == s.Length - 1)
                        {
                            resp.Add(new List<string>() { s1 });
                        }
                        else
                        {
                            var rest = s.Substring(i + 1, s.Length - i - 1);
                            var r = Partition(rest);
                            foreach (var l in r)
                            {
                                var nl = new List<string>() { s1 };
                                nl.AddRange(l);
                                resp.Add(nl);
                            }
                        }
                    }
                }
                return resp;
            }
            public bool IsPal(string s)
            {
                int l = 0;
                int r = s.Length - 1;
                while (l < r)
                {
                    if (s[l] != s[r]) return false;
                    l++; r--;
                }

                return true;
            }
        }
    }
}
