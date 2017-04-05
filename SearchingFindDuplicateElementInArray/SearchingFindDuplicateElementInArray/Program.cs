using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingFindDuplicateElementInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindDuplicate(new List<int>() { 0, 3, 1, 2, 2 });
        }

        public static int FindDuplicate(List<int> a)
        {
            var xorArray = 0;
            for (int i = 0; i < a.Count; ++i)
            {
                xorArray ^= a[i];
            }

            return xorArray;
        }
    }
}
