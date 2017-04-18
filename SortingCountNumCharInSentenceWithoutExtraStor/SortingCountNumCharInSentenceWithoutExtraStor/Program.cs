using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingCountNumCharInSentenceWithoutExtraStor
{
    class Program
    {
        static void Main(string[] args)
        {
            CountNumberCharWithoutExtraStorage("gfghghghtabca");
        }

        public static void CountNumberCharWithoutExtraStorage(string s)
        {
            var sortedS = new string(s.OrderBy(c => c).ToArray());
            var prev = sortedS[0];
            var count = 1;
            for(int i = 1; i < sortedS.Length; ++i)
            {
                if (sortedS[i] == prev) count++;
                else
                {
                    Console.WriteLine("char:{0}, count:{1}", prev, count);
                    prev = sortedS[i];
                    count = 1;
                }
            }
            Console.WriteLine("char:{0}, count:{1}", prev, count);
        }
    }
}
