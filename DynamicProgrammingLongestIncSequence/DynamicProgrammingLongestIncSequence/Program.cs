using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingLongestIncSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] {0, -1, 4, 5, 6, 2, 3 };
            var r = GetLongestIncSequence(a);
        }

        public static int GetLongestIncSequence(int []a)
        {
            int []maxAtIndex = Enumerable.Repeat(1, a.Length).ToArray();
            for (int i = 1; i < a.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (a[i] > a[j])
                    {
                        maxAtIndex[i] = Math.Max(maxAtIndex[i], maxAtIndex[j] + 1);
                    }
                }
            }

            return maxAtIndex.Max();
        }
    }
}
