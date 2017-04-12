using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesGetLongestSubArrayNoDups
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = LongestSubNoDups("fsfetwenwe"); // sfetw
            r = LongestSubNoDups("abcdaeif"); // bcdaeif
            r = LongestSubNoDups("abkcdaeibc"); // bkcdaei
            r = LongestSubNoDups("abcdaeibf"); // cdaeibf
        }

        public static string LongestSubNoDups(string s)
        {
            var charPos = new Dictionary<char, int>();
            var maxSofar = 0;
            var indexLastestDup = 0;
            var StartEnd = new Tuple<int, int>(0, 0);
            for (int i = 0; i < s.Length; ++i)
            {
                var pos = 0;
                if (charPos.TryGetValue(s[i], out pos))
                {
                    if (pos >= indexLastestDup)
                    {
                        var localDist = i - 1 - indexLastestDup;
                        if (localDist > maxSofar)
                        {
                            maxSofar = localDist;
                            StartEnd = new Tuple<int, int>(indexLastestDup, i - 1);
                        }
                        indexLastestDup = pos + 1;
                        charPos[s[i]] = i;
                    }
                }
                else
                {
                    charPos.Add(s[i], i);
                }
            }

            var tailDist = s.Length - indexLastestDup;
            if (tailDist > maxSofar)
            {
                return s.Substring(indexLastestDup, tailDist);
            }

            return s.Substring(StartEnd.Item1, StartEnd.Item2);
        }
    }
}
