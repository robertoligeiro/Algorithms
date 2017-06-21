using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesLongArrayNoDupsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = LongestSubNoDups("fsfetwenwe"); // 5 - sfetw
            r = LongestSubNoDups("abcdaeif"); // 7 - bcdaeif
            r = LongestSubNoDups("abkcdaeibc"); // 7- bkcdaei
            r = LongestSubNoDups("abcdaeibf"); // 7 - cdaeibf
        }

        public static int LongestSubNoDups(string s)
        {
            var indexDups = new Dictionary<char, int>();
            var indexStartNoDups = 0;
            var result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var index = 0;
                if (indexDups.TryGetValue(s[i], out index))
                {
                    if (index >= indexStartNoDups)
                    {
                        result = Math.Max(result, i - indexStartNoDups);
                        indexStartNoDups = index + 1;
                    }
                    indexDups[s[i]] = i;
                }
                else indexDups.Add(s[i], i);
            }

            result = Math.Max(result, s.Length - indexStartNoDups);
            return result;
        }
    }
}
