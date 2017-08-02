using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode467.UniqueSubstringsWraparoundString
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindSubstringInWraproundString("zab");
            r = s.FindSubstringInWraproundString("zbcd");
        }
        public class Solution
        {
            public int FindSubstringInWraproundString(string p)
            {
                var characters = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z".Split(',').ToArray();
                var h = new HashSet<char>();
                var words = new HashSet<string>();
                var totalSequences = 0;
                for (int i = 0; i < p.Length; ++i)
                {
                    h.Add(p[i]);
                    int j = i + 1;
                    var prev = p[i] - 'a';
                    var countSeq = 0;
                    while (j < p.Length)
                    {
                        h.Add(p[j]);
                        var targetNext = (prev + 1) % 26;
                        if (p[j] != characters[targetNext].First()) break;
                        prev = targetNext;
                        countSeq += (j-i);
                        ++j;
                    }
                    totalSequences += countSeq;
                    if (j != i + 1)
                    {
                        i = j;
                    }
                }
                return h.Count + totalSequences;
            }
        }
    }
}
