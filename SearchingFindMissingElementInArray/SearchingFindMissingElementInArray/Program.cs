using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingFindMissingElementInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindMissing(new List<int>() { 5,0,3,1,2});
        }

        public static int FindMissing(List<int> a)
        {
            var xorArray = 0;
            var xorArrayFull = 0;
            for (int i = 0; i <= a.Count; ++i)
            {
                xorArrayFull ^= i;
                if(i < a.Count)
                    xorArray ^= a[i];
            }

            return xorArrayFull ^ xorArray;
        }
    }
}
