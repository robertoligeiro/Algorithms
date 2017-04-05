using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingFindMissingAndDupSimultaneously
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindMissingAndDuplicate(new List<int>() { 5, 3, 0, 3, 1, 2 });
        }

        // return: Missing, Dup
        public static Tuple<int, int> FindMissingAndDuplicate(List<int> a)
        {
            //Xor of all numbers 0 - (N - 1) XOR all elements in array
            var missXorDup = 0;
            for (int i = 0; i < a.Count; ++i)
            {
                missXorDup ^= i ^ a[i];
            }

            // get the lest significant bit that is set to 1 in xorArray
            var differBit = missXorDup & (~(missXorDup - 1));

            // make xor for all entries in the full array and the search array that has the differBit set to 1
            var missOrDup = 0;
            for (int i = 0; i < a.Count; ++i)
            {
                if ((i & differBit) == 1)
                {
                    missOrDup ^= i;
                }
                if ((a[i] & differBit) == 1)
                {
                    missOrDup ^= a[i];
                }
            }

            foreach (var i in a)
            {
                if (i == missOrDup)
                {
                    return new Tuple<int, int>(missOrDup ^ missXorDup, missOrDup);
                }
            }
            return new Tuple<int, int>(missOrDup, missOrDup ^ missXorDup);
        }
    }
}
