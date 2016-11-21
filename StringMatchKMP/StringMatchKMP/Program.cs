using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMatchKMP
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = CalculateKMP("acacabacacabacacac");
            var i = StringMatch("acacabacacaxacacabacacabacacac", "acacabacacabacacac", r);
        }

        static int StringMatch(string source, string pattern, int[] next)
        {
            int start = 0, i = 0, j = 0;

            while (start == 0 && i < source.Length)
            {
                if (source[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = next[j];
                    if (j == 0)
                    {
                        i++;
                    }
                }

                if (j == pattern.Length - 1) return i - (pattern.Length - 1);
            }
            return -1;
        }
        static int[] CalculateKMP(string s)
        {
            int[] ret = new int[s.Length];
            int i = 1;
            int j = 0;

            while (i < s.Length)
            {
                if (s[i] == s[j])
                {
                    ret[i++] = j + 1;
                    j++;
                }
                else
                {
                    j = j == 0 ? 0 : --j;
                    while (j > 0)
                    {
                        j = ret[j];
                        if (s[j] != s[i])
                        {
                            j = j == 0 ? 0 : --j;
                        }
                        else
                        {
                            ret[i] = j + 1;
                            i++;
                            j++;
                            break;
                        }
                    }
                    if (j == 0)
                    {
                        ret[i++] = 0;
                    }
                }
            }
            return ret;
        }
    }
}
