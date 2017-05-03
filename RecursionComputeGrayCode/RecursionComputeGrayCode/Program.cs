using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionComputeGrayCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = ComputeGrayCode(3);
        }

        public static List<int> ComputeGrayCode(int nbits)
        {
            var h = new HashSet<int>() { 1 };
            var r = new List<int>() { 1 };
            ComputeGrayCode(nbits, r, h);
            return r;
        }
        public static bool ComputeGrayCode(int nbits, List<int> r, HashSet<int> h)
        {
            if (r.Count == nbits)
            {
                return IsDiffByOne(r.Last(), r.First());
            }

            for (int i = 0; i < nbits; ++i)
            {
                var prev = r.Last();
                var nextCandidate = prev ^ (1 << i);
                if (h.Add(nextCandidate))
                {
                    r.Add(nextCandidate);
                    if (ComputeGrayCode(nbits, r, h))
                    {
                        return true;
                    }
                    h.Remove(nextCandidate);
                    r.RemoveAt(r.Count - 1);
                } 
            }
            return false;
        }

        public static bool IsDiffByOne(int x, int y)
        {
            var z = x ^ y;
            return z >= 1 && (z & (z - 1)) == 0;
        }
    }
}
