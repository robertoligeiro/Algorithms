using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode482.LicenseKeyFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.LicenseKeyFormatting("2-4A0r7-4k", 4);
        }

        public class Solution
        {
            public string LicenseKeyFormatting(string S, int K)
            {
                var resp = new StringBuilder();
                var countGroup = K;
                for (int i = S.Length - 1; i >= 0; --i)
                {
                    if (S[i] == '-') continue; 
                    if (countGroup-- > 0)
                    {
                        resp.Append(char.ToUpper(S[i]));
                        continue;
                    }

                    resp.Append("-");
                    resp.Append(char.ToUpper(S[i]));
                    countGroup = K - 1;
                }

                S = resp.ToString();
                return new string(S.ToCharArray().Reverse().ToArray());
            }
        }
    }
}
